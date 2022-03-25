using System;

namespace Domain.Domain
{
    public class Reservation
    {
        public Trip Trip { get; set; }
        public User User { get; set; }
        public int SeatsNumber { get; set; }
        internal Reservation(Trip trip, User user, int seatsNumber)
        {
            this.Trip = trip;
            this.User = user;
            this.SeatsNumber = seatsNumber;
            Validate();
        }
        public void Validate()
        {
            this.Trip.Validate();
            this.User.Validate();
            if (this.SeatsNumber < 1)
                throw new ArgumentException("Enter number of seats");
        }
        public override string ToString()
        {
            return "Reservation for trip to " + this.Trip.Destination + ", "
                + this.SeatsNumber + " seats";
        }
    }
}
