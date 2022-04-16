namespace Application.Models
{
    public record AgencyDTO
    {
        public int Id { get; init; }
        public string AgencyName { get; init; }
        public string PhoneNumber { get; init; }
    }
}
