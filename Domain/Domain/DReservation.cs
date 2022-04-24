using System;

namespace Domain.Domain
{
    public class DReservation
    {
        public DTrip Trip { get; set; }
        public DRegularUser RegularUser { get; set; }
        public int Seats { get; set; }
        internal DReservation(DTrip trip, DRegularUser regularUser, int seats)
        {
            Trip = trip;
            RegularUser = regularUser;
            Seats = seats;
            Validate();
        }
        internal void Validate()
        {
            Trip.Validate();
            RegularUser.Validate();
            if (Seats < 1)
                throw new ArgumentException("Enter number of seats");
        }
        public override string ToString()
        {
            return "Reservation for trip to " + Trip.Destination + ", "
                + Seats + " seats";
        }
    }
}
