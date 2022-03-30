using System;

namespace Application.Domain
{
    public class Reservation
    {
        public Trip Trip { get; set; }
        public User User { get; set; }
        public int SeatsNumber { get; set; }
        internal Reservation(Trip trip, User user, int seatsNumber)
        {
            Trip = trip;
            User = user;
            SeatsNumber = seatsNumber;
            Validate();
        }
        public void Validate()
        {
            Trip.Validate();
            User.Validate();
            if (SeatsNumber < 1)
                throw new ArgumentException("Enter number of seats");
        }
        public override string ToString()
        {
            return "Reservation for trip to " + Trip.Destination + ", "
                + SeatsNumber + " seats";
        }
    }
}
