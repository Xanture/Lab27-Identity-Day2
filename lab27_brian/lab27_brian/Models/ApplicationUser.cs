using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace lab27_brian.Models
{
    public class ApplicationUser : IdentityUser
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }

    }
}
