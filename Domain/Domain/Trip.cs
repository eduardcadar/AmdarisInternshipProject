using System;

namespace Domain.Domain
{
    public class Trip
    {
        public int Id { get; set; }
        public Agency Agency { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration { get; set; }
        public float Price { get; set; }
        public int Seats { get; set; }
        public Trip(Agency agency, string departureLocation, string destination, DateTime departureTime, TimeSpan duration, float price, int seats)
        {
            this.Agency = agency;
            this.DepartureLocation = departureLocation;
            this.Destination = destination;
            this.DepartureTime = departureTime;
            this.Duration = duration;
            this.Price = price;
            this.Seats = seats;
        }
        public override string ToString()
        {
            return this.DepartureLocation + " --> " + this.Destination + " on " + DepartureTime.ToString();
        }
    }
}
