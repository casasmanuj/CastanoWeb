namespace Castano.Data
{
    using System.Data.Entity;
    using System.Linq;

    public class CastanoRepository<T> : ICastanoRepository<T>
        where T : class
    {
        private readonly IDbSet<T> _dbSet;
        public CastanoRepository(IDbSet<T> set)
        {
            this._dbSet = set;
        }
        public IQueryable<T> All => this._dbSet.AsQueryable();
    }
}
