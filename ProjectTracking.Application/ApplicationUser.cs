using Microsoft.AspNetCore.Identity;

namespace ProjectTracking.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}