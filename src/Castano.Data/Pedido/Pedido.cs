namespace Castano.Data.Pedido
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    public class Pedido
    {
        [Required]
        public string Cliente { get; set; }
        [Required]
        public string Salon { get; set; }
        public string Observaciones { get; set; }

        public string FechaHora { get; set; }

        [Required]
        public DateTime? Prueba { get; set; }
        [Required]
        public DateTime? Inicio { get; set; }
        [Required]
        public DateTime? Finalizacion { get; set; }

        public List<Equipo> Equipos { get; set; }

        public bool IsValid()
        {
            return this.Prueba.HasValue && this.Inicio.HasValue && this.Finalizacion.HasValue && this.Equipos.Any(e => e.Cantidad > 0);
        }
    }
}