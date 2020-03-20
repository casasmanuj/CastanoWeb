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
        Task<ValidationResult> SendMail(Data.Pedido pedido);
    }

    public class EnvioMailService : IEnvioMailService
    {
        public async Task<ValidationResult> SendMail(Data.Pedido pedido)
        {
            var result = new ValidationResult();

            using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587))
            {
                var basicCredential = new NetworkCredential("cast.rosarioav@gmail.com", "BSAS2458");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress fromAddress = new MailAddress("from@yourdomain.com");
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = basicCredential;

                    message.From = fromAddress;
                    message.Subject = $"Nuevo Pedido -> {pedido.Cliente} para el día {pedido.Inicio.Value.ToShortDateString()} a las {pedido.Inicio.Value.ToShortTimeString()}";
                    // Set IsBodyHtml to true means you can send HTML email.
                    message.IsBodyHtml = true;
                    message.Body = this.CreateEmailBodyFromTemplate(pedido);

                    message.To.Add("casasmanuj@gmail.com.ar");

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

        public string CreateEmailBodyFromTemplate(Data.Pedido pedido)
        {
            string body = string.Empty;
            using (StreamReader reader = new StreamReader(Path.Combine("Template", "MailPedido.html")))
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
                var marcaConOperador = equipo.ConOperador ? "X" : string.Empty;
                var total = Math.Round((equipo.Cantidad * equipo.Precio), 2);
                tagEquipos.AppendLine("<tr>" +
                    $"<td style='text-align:center;'>{marcaConOperador}</td>" +
                    $"<td>{equipo.Nombre}</td>" +
                    $"<td>{equipo.Precio}</td>" +
                    $"<td>{total}</td>" +
                    "</tr>");
            }

            body = body.Replace("{Equipos}", tagEquipos.ToString());

            var totalEquipos = pedido.Equipos.Sum(e => e.TotalEquipo);
            var iva = Math.Round((totalEquipos * 0.21), 2);
            var totalFinal = totalEquipos + iva;
            body = body.Replace("{TotalEquipos}", totalEquipos.ToString());
            body = body.Replace("{IVA}", iva.ToString());
            body = body.Replace("{Total}", totalFinal.ToString());

            body = body.Replace("{Observaciones}", pedido.Observaciones);

            return body;
        }
    }
}
