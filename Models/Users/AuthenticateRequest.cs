using System.ComponentModel.DataAnnotations;

namespace UserDetailsApp.Models.Users
{
    public class AuthenticateRequest
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}