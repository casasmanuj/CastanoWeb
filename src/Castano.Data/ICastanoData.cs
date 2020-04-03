namespace Castano.Data
{
    using Castano.Data.Pedido;
    using Castano.Data.Identity;

    public interface ICastanoData
    {
        ICastanoRepository<Equipo> EquiposRepository { get; }
    }
}
