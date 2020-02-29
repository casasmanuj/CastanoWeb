using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Castano.Web.Controllers
{
    public class PedidoController : Controller
    {
        // GET: Pedido
        public ActionResult Create(string envioCorrecto, string envioIncorrecto)
        {
            if (!string.IsNullOrWhiteSpace(envioCorrecto)) ViewBag.Success = envioCorrecto;
            if (!string.IsNullOrWhiteSpace(envioIncorrecto)) ViewBag.Error = envioIncorrecto;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Models.Pedido pedido)
        {
            if(!pedido.Prueba.HasValue || !pedido.Inicio.HasValue || !pedido.Finalizacion.HasValue)
                return RedirectToAction("Create", new { envioIncorrecto = "Su pedido no ha podido enviarse. Aguarde un momento y vuelva a intentarlo." });

            //TODO: envio por correo a info@castano
            return RedirectToAction("Create", new { envioCorrecto = "Su pedido se envió éxitosamente. Estaremos comunicándonos con usted a la brevedad." });
        }
    }
}