using System;

namespace Application.Domain
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
        internal Trip(Agency agency, string departureLocation, string destination, DateTime departureTime, TimeSpan duration, float price, int seats)
        {
            this.Agency = agency;
            this.DepartureLocation = departureLocation;
            this.Destination = destination;
            this.DepartureTime = departureTime;
            this.Duration = duration;
            this.Price = price;
            this.Seats = seats;
            Validate();
        }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.DepartureLocation))
                throw new ArgumentException("Enter a departure location");
            if (string.IsNullOrWhiteSpace(this.Destination))
                throw new ArgumentException("Enter a destination");
            if (this.DepartureTime.CompareTo(DateTime.Now.AddHours(1)) < 0)
                throw new ArgumentException("Departure time should be at least one hour from now");
            if (this.Duration.Equals(TimeSpan.Zero))
                throw new ArgumentException("Enter a duration");
            if (this.Price <= 0)
                throw new ArgumentException("Enter a price");
            if (this.Seats <= 0)
                throw new ArgumentException("Enter number of seats");
        }
        public override string ToString()
        {
            return this.DepartureLocation + " --> " + this.Destination + " on " + DepartureTime.ToString();
        }
    }
}
