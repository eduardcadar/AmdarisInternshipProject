using System;

namespace Application.DTOs
{
    public record TripDTO
    {
        public int Id { get; set; }
        public AgencyUserDTO AgencyUser { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        public int SeatsLeft { get; set; }
    }
}
