using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TalentShowcasePlatform.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        // navigation
        public ICollection<Video>? Videos { get; set; }
    }
}
