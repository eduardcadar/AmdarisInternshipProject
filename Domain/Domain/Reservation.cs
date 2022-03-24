using System;

namespace Domain.Domain
{
    class Reservation
    {
        public Trip Trip { get; set; }
        public User User { get; set; }
        public int SeatsNumber { get; set; }
        public Reservation(Trip trip, User user, int seatsNumber)
        {
            if (seatsNumber < 1)
                throw new ArgumentException("Enter number of seats");
            this.Trip = trip;
            this.User = user;
            this.SeatsNumber = seatsNumber;
        }
        public override string ToString()
        {
            return "Reservation for trip to " + this.Trip.Destination + ", "
                + this.SeatsNumber + " seats";
        }
    }
}
