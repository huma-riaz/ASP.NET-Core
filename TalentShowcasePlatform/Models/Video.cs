using System;
using System.ComponentModel.DataAnnotations;

namespace TalentShowcasePlatform.Models
{
    public class Video
    {
        public int Id { get; set; }

        public string? UserId { get; set; }   

        [Required(ErrorMessage = "Title is required")]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public string Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
