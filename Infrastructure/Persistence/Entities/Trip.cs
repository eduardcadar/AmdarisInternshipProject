using System;
using System.Collections.Generic;

namespace Infrastructure.Persistence.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        public int Seats { get; set; }
        public string AgencyUserId { get; set; }
        public AgencyUser AgencyUser { get; set; } = null!;
        public ICollection<Reservation> Reservations { get; set; }
    }
}
