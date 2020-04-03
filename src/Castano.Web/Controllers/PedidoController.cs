namespace Castano.Web.Controllers
{
    using Castano.Data;
    using Castano.Data.Pedido;
    using Castano.Data.Identity;
    using Castano.Service;
    using Castano.Web.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using Newtonsoft.Json;
    using System;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using System.Threading.Tasks;

    [Authorize]
    public class PedidoController : Controller
    {
        private readonly IEnvioMailService _envioMailService;
        private readonly ICastanoData _data;
        private readonly AppUserManager _userManager;

        public PedidoController(IEnvioMailService envioMailService, ICastanoData data, AppUserManager appUserManager)
        {
            this._envioMailService = envioMailService;
            this._data = data;
            this._userManager = appUserManager;
        }

        // GET: Pedido/
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            if (User == null || User.Identity == null) return RedirectToAction("Login");

            var pedido = new Pedido
            {
                Cliente = User.Identity.Name,
                FechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            };

            pedido.Equipos = _data.EquiposRepository.All.ToList();

            return View(pedido);
        }

        [HttpPost]
        public JsonResult Create(ModelPedidoWeb pedidoWeb)
        {
            var pathEmail = Server.MapPath("~/Views/EmailTemplate/MailPedido.html");
            var pedidoParaEnviar = new Pedido
            {
                FechaHora = pedidoWeb.FechaHora,
                Cliente = pedidoWeb.Cliente,
                Salon = pedidoWeb.Salon,
                Prueba = pedidoWeb.Prueba,
                Inicio = pedidoWeb.Inicio,
                Finalizacion = pedidoWeb.Finalizacion,
                Equipos = pedidoWeb.EquiposRequeridos,
                Observaciones = pedidoWeb.Observaciones
            };

            //Elementos auxiliares
            var descuento = pedidoWeb.Descuento;
            var recargo = pedidoWeb.Recargo;

            if (pedidoParaEnviar.IsValid())
            {
                try
                {
                    var result = _envioMailService.SendMail(pedidoParaEnviar, descuento, recargo, pathEmail);

                    if (result.IsValid)
                    {
                        return new JsonResult
                        {
                            Data = new
                            {
                                fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                                envioCorrecto = true,
                                msg = "Su pedido se envió éxitosamente. Estaremos comunicándonos con usted a la brevedad."
                            },
                            JsonRequestBehavior = JsonRequestBehavior.AllowGet
                        };
                    }

                    return new JsonResult
                    {
                        Data = new
                        {
                            fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                            envioCorrecto = false,
                            msg = $"Su pedido no ha podido enviarse. Se ha producido un error. {result.MensajeErrores}"
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                catch (System.Exception exc)
                {
                    return new JsonResult 
                    { 
                        Data = new 
                        { 
                            fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm"), 
                            envioCorrecto = false, 
                            msg = $"Su pedido no ha podido enviarse. Se ha producido un error. {exc.Message}" 
                        }, 
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet 
                    };
                }
            }

            return new JsonResult 
            { 
                Data = new 
                { 
                    fechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm"), 
                    envioCorrecto = false, 
                    msg = "Su pedido no ha podido enviarse. El formulario que está intentando enviar no es válido, por favor corrija y vuelva a intentarlo." 
                }, 
                JsonRequestBehavior = JsonRequestBehavior.AllowGet 
            };
        }

        // GET: Pedido/Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Pedido/Login
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult> Login(Login login)
        {
            var secret = "6LfBQOIUAAAAAODnw5bhLcW7QO3nvL9EuZ5S27qC";
            var g_captcha = this.Request.Form["g-recaptcha-response"];

            var response = new WebClient().DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, g_captcha));
            var recaptchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(response);

            if (recaptchaResponse.Success)
            {
                var user = await _userManager.FindAsync(login.UserName, login.Password);

                if (user != null)
                {
                    AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                    var identity = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);

                    return RedirectToAction("Create", new { cliente = login.UserName });
                }
            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View(login);
        }

        // GET: /Pedido/LogOff
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

    }
}