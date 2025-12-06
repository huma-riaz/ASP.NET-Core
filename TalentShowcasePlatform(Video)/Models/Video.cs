using System;
using System.ComponentModel.DataAnnotations;

namespace TalentShowcasePlatform.Models
{
    public class Video
    {
        public int ID { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Url { get; set; }  // "videos/file.mp4"

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public string? UserId { get; set; }
        public DateTime UploadDate { get; set; } = DateTime.Now;

        public bool IsPublic { get; set; } = true;
        public bool AllowComments { get; set; } = true;
    }
}
