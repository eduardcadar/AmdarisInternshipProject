using Domain.Domain;

namespace Application.DTOs
{
    public record AgencyUserDTO
    {
        public int Id { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string PhoneNumber { get; init; }
        public DAgency Agency { get; init; }
    }
}
