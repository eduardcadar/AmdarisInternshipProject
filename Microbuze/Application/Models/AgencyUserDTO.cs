namespace Application.Models
{
    public record AgencyUserDTO
    {
        public int Id { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string PhoneNumber { get; init; }
        public AgencyDTO Agency { get; init; }
    }
}
