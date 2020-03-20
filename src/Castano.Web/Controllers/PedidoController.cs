namespace Castano.Web.Controllers
{
    using Castano.Service;
    using Castano.Web.Models;
    using Newtonsoft.Json;
    using System;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;

    [AllowAnonymous]
    public class PedidoController : Controller
    {
        private readonly IEnvioMailService _envioMailService;
        public PedidoController(IEnvioMailService envioMailService)
        {
            this._envioMailService = envioMailService;
        }

        // GET: Pedido/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Pedido/Login
        [HttpPost]
        public ActionResult Login(Login login)
        {
            var secret = "6LfBQOIUAAAAAODnw5bhLcW7QO3nvL9EuZ5S27qC";
            var g_captcha = this.Request.Form["g-recaptcha-response"];

            var response = new WebClient().DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secret, g_captcha));
            var recaptchaResponse = JsonConvert.DeserializeObject<RecaptchaResponse>(response);

            if (recaptchaResponse.Success)
            {
                switch (login.UserName)
                {
                    case "info":
                        if (login.Password == "info123")
                            return RedirectToAction("Create");
                        break;

                    default:
                        break;
                }
            }

            ViewBag.Error = "Usuario o contraseña incorrectos.";
            return View();
        }

        // GET: Pedido/Create
        public ActionResult Create(string cliente)
        {
            var pedido = new Data.Pedido
            {
                Cliente = cliente ?? "Cliente Prueba",
                FechaHora = DateTime.Now.ToString("dd/MM/yyyy HH:mm")
            };

            return View(pedido);
        }

        [HttpPost]
        public async Task<JsonResult> Create(Data.Pedido pedido)
        {
            if (pedido.IsValid())
            {
                try
                {
                    await _envioMailService.SendMail(pedido);
                    
                    return new JsonResult { Data = new { envioCorrecto = true, msg = "Su pedido se envió éxitosamente. Estaremos comunicándonos con usted a la brevedad." }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

                }
                catch (System.Exception exc)
                {
                    return new JsonResult { Data = new { envioCorrecto = false, msg = $"Su pedido no ha podido enviarse. Se ha producido un error. {exc.Message}" }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }

            return new JsonResult { Data = new { envioCorrecto = false, msg = "Su pedido no ha podido enviarse. El formulario que está intentando enviar no es válido, por favor corrija y vuelva a intentarlo." }, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }
    }
}