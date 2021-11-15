
namespace PracticeAspNetCoreWithKunvenkat.Models
{

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public string City { set; get; }
    }
}
