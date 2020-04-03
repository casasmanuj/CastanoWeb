namespace Castano.Data.Identity
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AppUser : IdentityUser
    {
        public override string Id { get; set; }
    }
}
