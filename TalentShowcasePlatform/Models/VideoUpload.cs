using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TalentShowcasePlatform.Models
{
    public class VideoUpload
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public IFormFile File { get; set; }
    }
}
