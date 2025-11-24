using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string? Description { get; set; }

        [Required]
        public string Url { get; set; }

        // Foreign key to Category
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.UtcNow;

        public bool IsPublic { get; set; } = true;
        public bool CommentsAllowed { get; set; } = true;

        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
    }
}
