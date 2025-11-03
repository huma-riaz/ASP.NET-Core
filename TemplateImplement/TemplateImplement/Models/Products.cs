using System.ComponentModel.DataAnnotations;

namespace TemplateImplement.Models
{
    public class Products
    {
        [Key]
        public Guid ID { get; set; }
    }
}
