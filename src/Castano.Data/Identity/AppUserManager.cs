namespace Castano.Data.Identity
{
    using Microsoft.AspNet.Identity;
    using System;
    using System.Threading.Tasks;

    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager()
            : base(new AppUserSore<AppUser>())
        {
        }

        public override Task<AppUser> FindAsync(string userName, string password)
        {
            var taskInvoke = Task<AppUser>.Factory.StartNew(() =>
            {
                if (userName == "Holiday" && password == "Holiday-123")
                {
                    return new AppUser { Id = "Holiday", UserName = "Holiday Inn" };
                }
                if (userName == "Express" && password == "Express-123")
                {
                    return new AppUser { Id = "HolidayExpress", UserName = "Holiday Express" };
                }
                if (userName == "Presidente" && password == "Presidente-123")
                {
                    return new AppUser { Id = "SolansPresidente", UserName = "Solans Presidente" };
                }
                if (userName == "Riviera" && password == "Riviera-123")
                {
                    return new AppUser { Id = "SolansRiviera", UserName = "Solans Riviera" };
                }
                if (userName == "Libertador" && password == "Libertador-123")
                {
                    return new AppUser { Id = "SolansLibertador", UserName = "Solans Libertador" };
                }
                if (userName == "Invitado" && password == "Invitado-" + (DateTime.Today.Year + DateTime.Today.Month + DateTime.Today.Day).ToString())
                {
                    return new AppUser { Id = "Invitado", UserName = "Invitado" };
                }
                return null;
            });

            return taskInvoke;
        }
    }
}
