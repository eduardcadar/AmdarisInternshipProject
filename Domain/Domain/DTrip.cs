using System;
using Domain.Visitor;

namespace Domain.Domain
{
    public class DTrip : IVisitable
    {
        public int Id { get; set; }
        public DAgencyUser AgencyUser { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration { get; set; }
        public double Price { get; set; }
        public int Seats { get; set; }
        public DTrip()
        {
            DepartureLocation = "default";
            Destination = "default";
            DepartureTime = DateTime.Now.AddMinutes(60);
            Duration = TimeSpan.FromSeconds(1);
            Price = 1;
            Seats = 1;
        }
        public DTrip(DAgencyUser agencyUser, string departureLocation, string destination, DateTime departureTime, TimeSpan duration, double price, int seats)
        {
            AgencyUser = agencyUser;
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
                throw new ArgumentException("Enter departure location");
            if (string.IsNullOrWhiteSpace(Destination))
                throw new ArgumentException("Enter destination");
            if (DepartureTime.CompareTo(DateTime.Now.AddMinutes(30)) < 0)
                throw new ArgumentException("Departure time should be at least 30 minutes from now");
            if (Duration.Equals(TimeSpan.Zero))
                throw new ArgumentException("The trip should last at least 1 minute");
            if (Price <= 0)
                throw new ArgumentException("Enter the price");
            if (Seats <= 0)
                throw new ArgumentException("Enter the number of seats");
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
