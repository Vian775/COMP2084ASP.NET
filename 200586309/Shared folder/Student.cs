using System.ComponentModel.DataAnnotations;

namespace _200586309.Shared_folder
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Email Address")]
        [EmailAddress]
        public string? EmailAddress { get; set; }
    }
}

