namespace Castano.Service
{
    using Castano.Data;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public interface IEventoService
    {
        List<Evento> ListEventos(string path);
    }
    public class EventoService : IEventoService
    {
        public List<Evento> ListEventos(string path)
        {
            using (StreamReader file = File.OpenText(path))
            {
                var eventos = JsonConvert.DeserializeObject<ICollection<Evento>>(file.ReadToEnd(), new IsoDateTimeConverter());

                return eventos.OrderByDescending(e => e.Dia).ToList();
            }
        }
    }
}
