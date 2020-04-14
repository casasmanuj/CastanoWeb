namespace Castano.Data
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Evento
    {
        [Display(Name = "Día")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        public DateTime Dia { get; set; }

        public string Cliente { get; set; }

        public string Nombre { get; set; }

        [Display(Name = "Salón")]
        public string Salon { get; set; }
    }
}
