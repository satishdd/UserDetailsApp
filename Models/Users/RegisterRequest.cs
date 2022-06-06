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

        [Required]
        public string Email { get; set; }

        [StringLength(60, MinimumLength = 6)]
        [Required]
        public string Password { get; set; }
    }
}