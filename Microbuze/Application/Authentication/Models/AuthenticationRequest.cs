namespace Application.Authentication.Models
{
    public class AuthenticationRequest
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
