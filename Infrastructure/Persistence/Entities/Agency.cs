using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities
{
    public class Agency
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<AgencyUser> AgencyUsers { get; set; }
        public ICollection<Trip> Trips { get; set; }
    }
}
