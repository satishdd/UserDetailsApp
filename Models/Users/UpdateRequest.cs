namespace UserDetailsApp.Models.Users
{
    public class UpdateRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}