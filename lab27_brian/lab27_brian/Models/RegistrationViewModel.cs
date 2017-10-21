using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lab27_brian.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Compare("Email", ErrorMessage = "Your Email address does not match")]
        public string ConrimEmail { get; set; }
        [Required]
        [DataType(DataType.Password, ErrorMessage = "Your password doesn't meet the minimum requiments")]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Your Password does not match")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}
