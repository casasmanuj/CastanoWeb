using Castano.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Castano.Web.Controllers
{
    public class EventoController : Controller
    {
        // GET: Evento
        public ActionResult Index()
        {
            return View();
        }

        // GET: Evento/UploadFile
        public ActionResult UploadFile()
        {
            return View();
        }

        // POST: Evento/UploadFile
        [HttpPost]
        public ActionResult UploadFile(string Password)
        {
            if(Password != "CAST2458")
                return View();

            
            var file = Request.Files[0];
            if (file != null && file.ContentLength > 0)
            {
                using (StreamReader memStream = new StreamReader(file.InputStream))
                {
                    var content = memStream.ReadToEnd();
                    //
                    if (string.IsNullOrEmpty(content)) throw new ApplicationException("El archivo está vacio.");

                    var filas = content.Trim().Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).Skip(1);
                    var numeroFila = 2;
                    List<Evento> eventos = new List<Evento>();
                    foreach (var fila in filas)
                    {
                        var evento = new Evento(fila, numeroFila);

                        eventos.Add(evento);

                        numeroFila++;
                    }

                    ViewBag.Success = "Se agregaron los eventos.";
                    return View(eventos);
                }
            }
            return View();
        }
    }
}