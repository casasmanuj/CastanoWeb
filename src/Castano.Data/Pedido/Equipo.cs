namespace Castano.Data.Pedido
{
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
