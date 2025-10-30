using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Min length is 3")]
        [MaxLength(20, ErrorMessage = "Max length is 20")]
        public string Name { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }

        public int Age { get; set; }
        public Courses course { get; set; }
    }

    public enum Courses
    {
        Medical, Engeneering, Science, Arts
    }
}
