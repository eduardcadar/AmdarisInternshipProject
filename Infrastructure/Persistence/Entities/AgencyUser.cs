namespace Infrastructure.Persistence.Entities
{
    public class AgencyUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
    }
}
