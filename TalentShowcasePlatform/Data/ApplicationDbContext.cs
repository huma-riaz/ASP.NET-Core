using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalentShowcasePlatform.Models;

namespace TalentShowcasePlatform.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Future modules: Videos, Comments, Groups, etc.
         public DbSet<Video> Videos { get; set; }
    }
}
