namespace Castano.Data
{
    using System.Collections.Generic;
    using System.Linq;

    public class CastanoMemoryRepository<T> : ICastanoRepository<T>
        where T : class
    {
        private readonly HashSet<T> _dbSet;
        public CastanoMemoryRepository(HashSet<T> set)
        {
            this._dbSet = set;
        }

        public virtual IQueryable<T> All => this._dbSet.AsQueryable();
    }
}
