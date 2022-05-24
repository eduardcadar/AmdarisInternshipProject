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
        public DTrip()
        {
            DepartureLocation = "default";
            Destination = "default";
            DepartureTime = DateTime.Now.AddMinutes(60);
            Duration = TimeSpan.FromSeconds(1);
            Price = 1;
            Seats = 1;
        }
        public DTrip(DAgency agency, string departureLocation, string destination, DateTime departureTime, TimeSpan duration, double price, int seats)
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
                throw new ArgumentException("Introdu locatie de plecare");
            if (string.IsNullOrWhiteSpace(Destination))
                throw new ArgumentException("Introdu destinatie");
            if (DepartureTime.CompareTo(DateTime.Now.AddMinutes(30)) < 0)
                throw new ArgumentException("Ora plecarii trebuie sa fie peste cel putin 30 minute");
            if (Duration.Equals(TimeSpan.Zero))
                throw new ArgumentException("Introdu durata");
            if (Price <= 0)
                throw new ArgumentException("Introdu pretul");
            if (Seats <= 0)
                throw new ArgumentException("Introdu numarul de locuri");
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
