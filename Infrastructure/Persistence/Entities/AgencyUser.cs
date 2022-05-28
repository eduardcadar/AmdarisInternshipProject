namespace Infrastructure.Persistence.Entities
{
    public class AgencyUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Agency { get; set; } = null!;
    }
}
