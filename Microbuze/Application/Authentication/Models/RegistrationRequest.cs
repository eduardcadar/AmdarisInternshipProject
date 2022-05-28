using System.ComponentModel.DataAnnotations;

namespace Application.Authentication.Models
{
    public class RegistrationRequest
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public bool IsAgency { get; set; } = false;
        public string Agency { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
