namespace Castano.Web.Models
{
    using Castano.Data.Pedido;
    using System;
    using System.Collections.Generic;

    public class ModelPedidoWeb
    {
        public string Cliente { get; set; }
        public string Salon { get; set; }
        public string Observaciones { get; set; }

        public string FechaHora { get; set; }
        public DateTime? Prueba { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Finalizacion { get; set; }

        public double TotalPedido { get; set; }
        public double Descuento { get; set; }
        public double Recargo { get; set; }
        public double TotalFinal { get; set; }

        public List<Equipo> EquiposRequeridos { get; set; }
    }
}