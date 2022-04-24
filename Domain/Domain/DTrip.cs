using System;
using Domain.Visitor;

namespace Domain.Domain
{
    public class DTrip : IVisitable
    {
        public int Id { get; set; }
        public DAgency Agency { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        public int Seats { get; set; }
        internal DTrip(DAgency agency, string departureLocation, string destination, DateTime departureTime, TimeSpan duration, double price, int seats)
        {
            Agency = agency;
            DepartureLocation = departureLocation;
            Destination = destination;
            DepartureTime = departureTime;
            Duration = duration;
            Price = price;
            Seats = seats;
            Validate();
        }

        internal void Validate()
        {
            if (string.IsNullOrWhiteSpace(DepartureLocation))
                throw new ArgumentException("Enter a departure location");
            if (string.IsNullOrWhiteSpace(Destination))
                throw new ArgumentException("Enter a destination");
            if (DepartureTime.CompareTo(DateTime.Now.AddMinutes(30)) < 0)
                throw new ArgumentException("Departure time should be at least 30 minutes from now");
            if (Duration.Equals(TimeSpan.Zero))
                throw new ArgumentException("Enter a duration");
            if (Price <= 0)
                throw new ArgumentException("Enter a price");
            if (Seats <= 0)
                throw new ArgumentException("Enter number of seats");
        }
        public override string ToString()
        {
            return DepartureLocation + " --> " + Destination + " on " + DepartureTime.ToString();
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
