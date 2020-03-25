namespace Castano.Service
{
    using Castano.Service.Models;
    using System;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Text;
    using System.Threading.Tasks;
    public interface IEnvioMailService
    {
        ValidationResult SendMail(Data.Pedido pedido, double descuento, double recargo, string pathEmail);
    }

    public class EnvioMailService : IEnvioMailService
    {
        public ValidationResult SendMail(Data.Pedido pedido, double descuento, double recargo, string pathEmail)
        {
            var result = new ValidationResult();

            var fromAddress = new MailAddress("cast.rosarioav@gmail.com");
            var fromPassword = "BSAS24580715";
            var toAddress = new MailAddress("casasmanuj@gmail.com");

            string subject = $"Nuevo Pedido -> {pedido.Cliente} para el día {pedido.Inicio.Value.ToShortDateString()} a las {pedido.Inicio.Value.ToShortTimeString()}";
            string body = this.CreateEmailBodyFromTemplate(pedido, descuento, recargo, pathEmail);

            SmtpClient smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                IsBodyHtml = true,
                Body = body
            })

                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    result.AddError(ex.Message);
                }

            return result;
        }

        public string CreateEmailBodyFromTemplate(Data.Pedido pedido, double descuento, double recargo, string pathEmail)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(pathEmail))
            {
                body = reader.ReadToEnd();
            }
            var cantidadDias = (pedido.Finalizacion.Value - pedido.Inicio.Value).Days;
            body = body.Replace("{FechaHora}", pedido.FechaHora);

            body = body.Replace("{Cliente}", pedido.Cliente);
            body = body.Replace("{Salon}", pedido.Salon);

            body = body.Replace("{Prueba}", pedido.Prueba.Value.ToString("dd/MM/yyyy HH:mm"));
            body = body.Replace("{Inicio}", pedido.Inicio.Value.ToString("dd/MM/yyyy HH:mm"));
            body = body.Replace("{Finalizacion}", pedido.Finalizacion.Value.ToString("dd/MM/yyyy HH:mm"));
            body = body.Replace("{CantidadDias}", cantidadDias.ToString());

            StringBuilder tagEquipos = new StringBuilder();
            foreach (var equipo in pedido.Equipos)
            {
                var marcaConOperador = (equipo.ConOperador ?? false) ? "X" : string.Empty;
                var total = Math.Round((equipo.Cantidad * equipo.Precio), 2);
                tagEquipos.AppendLine("<tr>" +
                    $"<td style='text-align:center;'>{marcaConOperador}</td>" +
                    $"<td>{equipo.Nombre}</td>" +
                    $"<td style='text-align:center;'>{equipo.Precio:n0}</td>" +
                    $"<td style='text-align:right;'>{total:n0}</td>" +
                    "</tr>");
            }

            body = body.Replace("{Equipos}", tagEquipos.ToString());

            var totalEquipos = pedido.Equipos.Sum(e => e.TotalEquipo) * cantidadDias;
            var iva = Math.Round((totalEquipos * 0.21), 2);
            var totalFinal = totalEquipos + iva - descuento + recargo;
            body = body.Replace("{TotalEquipos}", totalEquipos.ToString("n0"));
            body = body.Replace("{IVA}", iva.ToString("n0"));
            body = body.Replace("{Descuento}", descuento.ToString("n0"));
            body = body.Replace("{Recargo}", recargo.ToString("n0"));
            body = body.Replace("{Total}", totalFinal.ToString("n0"));

            body = body.Replace("{Observaciones}", pedido.Observaciones);

            return body;
        }
    }
}
