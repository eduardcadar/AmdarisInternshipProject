using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities
{
    public class RegularUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
