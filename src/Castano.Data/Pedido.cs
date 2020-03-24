namespace Castano.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Pedido
    {
        public string Cliente { get; set; }
        public string Salon { get; set; }
        public string Observaciones { get; set; }

        public string FechaHora { get; set; }
        public DateTime? Prueba { get; set; }
        public DateTime? Inicio { get; set; }
        public DateTime? Finalizacion { get; set; }

        public List<Equipo> Equipos { get; set; }

        public bool IsValid()
        {
            return this.Prueba.HasValue && this.Inicio.HasValue && this.Finalizacion.HasValue && this.Equipos.Any(e => e.Cantidad > 0);
        }
    }

    public class Equipo
    {
        public bool SoloConAnticipacion { get; set; }
        public bool? ConOperador { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string IndicadoPara { get; set; }
        public string Aclaracion { get; set; }
        public double Precio { get; set; }
        public string Tipo { get; set; }
        public double TotalEquipo => Cantidad * Precio;
    }
}