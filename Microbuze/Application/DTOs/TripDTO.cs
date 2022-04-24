using System;

namespace Application.DTOs
{
    public record TripDTO
    {
        public int Id { get; init; }
        public AgencyDTO Agency { get; init; }
        public string DepartureLocation { get; init; }
        public string Destination { get; init; }
        public DateTime DepartureTime { get; init; }
        public TimeSpan Duration { get; init; }
        public double Price { get; init; }
        public int Seats { get; init; }
    }
}
