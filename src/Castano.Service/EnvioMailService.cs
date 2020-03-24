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
        Task<ValidationResult> SendMail(Data.Pedido pedido, double descuento, double recargo, string pathEmail);
    }

    public class EnvioMailService : IEnvioMailService
    {
        public async Task<ValidationResult> SendMail(Data.Pedido pedido, double descuento, double recargo, string pathEmail)
        {
            var result = new ValidationResult();

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                var basicCredential = new NetworkCredential("cast.rosarioav@gmail.com", "BSAS2458");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress("cast.rosarioav@gmail.com");
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = $"Nuevo Pedido -> {pedido.Cliente} para el día {pedido.Inicio.Value.ToShortDateString()} a las {pedido.Inicio.Value.ToShortTimeString()}";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = this.CreateEmailBodyFromTemplate(pedido, descuento, recargo, pathEmail);

                    message.To.Add("casasmanuj@gmail.com");

                    try
                    {
                        await smtpClient.SendMailAsync(message);
                    }
                    catch (Exception ex)
                    {
                        result.AddError(ex.Message);
                    }

                    return result;
                }
            }
        }

        public string CreateEmailBodyFromTemplate(Data.Pedido pedido, double descuento, double recargo, string pathEmail)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(pathEmail))
            {
                body = reader.ReadToEnd();
            }

            body = body.Replace("{FechaHora}", pedido.FechaHora);

            body = body.Replace("{Cliente}", pedido.Cliente);
            body = body.Replace("{Salon}", pedido.Salon);

            body = body.Replace("{Prueba}", pedido.Prueba.Value.ToShortDateString());
            body = body.Replace("{Inicio}", pedido.Inicio.Value.ToShortDateString());
            body = body.Replace("{Finalizacion}", pedido.Finalizacion.Value.ToShortDateString());
            body = body.Replace("{CantidadDias}", ((pedido.Finalizacion.Value - pedido.Inicio.Value).Days).ToString());

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

            var totalEquipos = pedido.Equipos.Sum(e => e.TotalEquipo);
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
