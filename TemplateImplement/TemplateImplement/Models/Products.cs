using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TemplateImplement.Models
{
    public class Products
    {
        [Key]
        public Guid ID { get; set; }

        [Column("prod_name",TypeName ="Varchar(100)")]
        public string Name { get; set; }


        [Column("prod_desc", TypeName = "Text")]
        public string Description { get; set; }


        [Column("prod_price", TypeName = "decimal")]
        public decimal Price { get; set; }


        [Column("prod_stock")]
        public int Stock { get; set; }

        [Column("prod_image", TypeName ="Varchar(300)")]
        public string? Image { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now; 
            

    }
}
