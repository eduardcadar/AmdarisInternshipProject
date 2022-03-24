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
            ValidateTrip(departureLocation, destination, departureTime, duration, price, seats);
            this.Agency = agency;
            this.DepartureLocation = departureLocation;
            this.Destination = destination;
            this.DepartureTime = departureTime;
            this.Duration = duration;
            this.Price = price;
            this.Seats = seats;
        }

        private void ValidateTrip(string departureLocation, string destination, DateTime departureTime, TimeSpan duration, float price, int seats)
        {
            if (departureLocation == "")
                throw new ArgumentException("Enter a departure location");
            if (destination == "")
                throw new ArgumentException("Enter a destination");
            if (departureTime.CompareTo(DateTime.Now.AddHours(1)) < 0)
                throw new ArgumentException("Departure time should be at least one hour from now");
            if (duration.Equals(TimeSpan.Zero))
                throw new ArgumentException("Enter a duration");
            if (price <= 0)
                throw new ArgumentException("Enter a price");
            if (seats <= 0)
                throw new ArgumentException("Enter number of seats");
        }
        public override string ToString()
        {
            return this.DepartureLocation + " --> " + this.Destination + " on " + DepartureTime.ToString();
        }
    }
}
