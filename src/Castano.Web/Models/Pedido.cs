using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Castano.Web.Models
{
    public class Pedido
    {
        public string Salon { get; set; }

        public DateTime? Prueba { get; set; }

        public DateTime? Inicio { get; set; }

        public DateTime? Finalizacion { get; set; }

        public int CantidadDias => Inicio.HasValue && Finalizacion.HasValue 
            ? (Finalizacion.Value - Inicio.Value).Days 
            : 0;
    }
}