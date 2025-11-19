using Microsoft.AspNetCore.Identity;

namespace TalentShowcasePlatform.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfileImage { get; set; } = "default.png"; // Default image to avoid NULL errors
    }
}
