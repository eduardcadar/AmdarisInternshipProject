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
        public int AgencyId { get; set; }
        public Agency Agency { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
