namespace Castano.Data
{
    using System.Linq;

    public interface ICastanoRepository<T> where T : class
    {
        IQueryable<T> All { get; }
    }
}
