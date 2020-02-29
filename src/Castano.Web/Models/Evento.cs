using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Castano.Web.Models
{
    public class Evento
    {
        DateTime Dia { get; set; }
        public string Cliente { get; set; }
        public string Salon { get; set; }
        public string Nombre { get; set; }

        public Evento(string Linea, int NumeroFila)
        {
            var separador = new List<string>
                    {
                        ";",
                        "\t",
                        ",",
                        " "
                    };

            var data = Linea.Split(separador.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();

            var parseDia = DateTime.TryParse(data[0], out DateTime dia);

            if (!parseDia)
                throw new Exception(string.Format("El archivo tiene un error en la fila {0}", NumeroFila));

            Dia = dia;
            Cliente = data[1];
            Salon = data[2];
            Nombre = data[3];
        }
    }
}