namespace Castano.Data.Identity
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Threading.Tasks;

    public class AppUserSore<T> : IUserStore<T> where T : AppUser
    {
        public Task CreateAsync(T user)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(T user)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByNameAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
