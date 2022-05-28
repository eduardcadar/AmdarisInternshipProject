using Microsoft.AspNetCore.Identity;

namespace Authentication
{
    public class AppUser : IdentityUser
    {
        public bool IsAgency { get; set; }
    }
}
