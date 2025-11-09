using Microsoft.EntityFrameworkCore;

namespace TemplateImplement.Models
{
    public class TemplateContext : DbContext
    {
        public TemplateContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Products> tbl_products { get; set; }

    }
}
