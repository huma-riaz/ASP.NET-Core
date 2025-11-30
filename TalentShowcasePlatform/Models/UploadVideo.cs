using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TalentShowcasePlatform.Models
{
    public class UploadVideo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]  
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please select a video file")]
        public IFormFile VideoFile { get; set; }

        public bool IsPublic { get; set; } = true;
        public bool CommentsAllowed { get; set; } = true;
    }
}
