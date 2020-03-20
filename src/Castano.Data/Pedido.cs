using System;
using System.Collections.Generic;
using System.Linq;

namespace Castano.Data
{
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
        public List<Equipo> EquiposRequeridosParaEvento => this.Equipos.Where(e => e.Cantidad > 0).ToList();

        public Pedido()
        {
            this.Equipos = new List<Equipo>
            {
                new Equipo{ Nombre = "Proyección Multimedia S2000", Precio = 10.2, Descripcion = "Una descripción..." },
                new Equipo{ Nombre = "Proyección Multimedia X2000", Precio = 100 },
                new Equipo{ Nombre = "Proyección Multimedia X3000", Precio = 100 },
                new Equipo{ Nombre = "Notebook", Precio = 12.45 },
                new Equipo{ Nombre = "Control Remoto Presentaciones", Precio = 12.45 },
                new Equipo{ Nombre = "PC Multimedia", Precio = 12.45 },
                new Equipo{ Nombre = "Monitor CRT 15''", Precio = 12.45 },
                new Equipo{ Nombre = "Monitor LCD 17''", Precio = 12.45 },
                new Equipo{ Nombre = "Impresora chorro tinta", Precio = 12.45 },
                new Equipo{ Nombre = "Reproducto DVD", Precio = 12.45 },
                new Equipo{ Nombre = "Sonido Base", Precio = 12.45 },
                new Equipo{ Nombre = "Volante", Precio = 12.45 },
                new Equipo{ Nombre = "Corbatero", Precio = 12.45 },
                new Equipo{ Nombre = "Head Set", Precio = 12.45 },
                new Equipo{ Nombre = "MIC inalámbrico Volante", Precio = 12.45 },
                new Equipo{ Nombre = "MIC inalámbrico Solapero", Precio = 12.45 },
                new Equipo{ Nombre = "MIC inalámbrico Head Set", Precio = 12.45 },
                new Equipo{ Nombre = "MIC cable", Precio = 12.45 },
                new Equipo{ Nombre = "Sonido Económico", Precio = 12.45 },
                new Equipo{ Nombre = "Minicomponente", Precio = 12.45 },
                new Equipo{ Nombre = "OTROS I", Precio = 12.45 },
                new Equipo{ Nombre = "OTROS II", Precio = 12.45 },
                new Equipo{ Nombre = "OTROS III", Precio = 12.45 }
            };
        }

        public bool IsValid()
        {
            return this.Prueba.HasValue && this.Inicio.HasValue && this.Finalizacion.HasValue && this.Equipos.Any(e => e.Cantidad > 0);
        }
    }

    public class Equipo
    {
        public bool ConOperador { get; set; }
        public int Cantidad { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string Descripcion { get; set; }
        public double TotalEquipo => Cantidad * Precio;
    }
}