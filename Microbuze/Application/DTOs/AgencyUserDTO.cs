namespace Application.DTOs
{
    public record AgencyUserDTO
    {
        public string Id { get; init; }
        public string Username { get; init; }
        public string PhoneNumber { get; init; }
        public string Agency { get; init; }
    }
}
