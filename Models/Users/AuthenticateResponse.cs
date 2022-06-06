namespace UserDetailsApp.Models.Users
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long PhoneNo { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}