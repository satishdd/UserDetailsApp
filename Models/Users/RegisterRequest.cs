using System.ComponentModel.DataAnnotations;

namespace UserDetailsApp.Models.Users
{
    public class RegisterRequest
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        public long PhoneNo { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6, ErrorMessage ="Password must be minimum of 6 Charactors")]
        public string Password { get; set; }
    }
}