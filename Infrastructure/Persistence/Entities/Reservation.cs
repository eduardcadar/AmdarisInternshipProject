namespace Infrastructure.Persistence.Entities
{
    public class Reservation
    {
        public int TripId { get; set; }
        public Trip Trip { get; set; }
        public int RegularUserId { get; set; }
        public RegularUser RegularUser { get; set; }
        public int Seats { get; set; }
    }
}
