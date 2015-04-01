using Microsoft.AspNet.Identity.EntityFramework;

namespace SampleSTS.Web.Models
{
    public class AuthenticationContext : IdentityDbContext<ApplicationUser>
    {
        public AuthenticationContext()
            : base("AuthenticationConnection", false)
        {
        }

        public static AuthenticationContext Create()
        {
            return new AuthenticationContext();
        }
    }
}
