namespace Castano.Data
{
    using Castano.Data.Pedido;
    using Castano.Data.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class CastanoContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Pedido.Pedido> Pedidos { get; set; }
    }
}
