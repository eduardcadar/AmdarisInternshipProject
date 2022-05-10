namespace Infrastructure.Persistence.Entities
{
    public class Reservation
    {
        public int TripId { get; set; }
        public Trip Trip { get; set; } = null!;
        public int RegularUserId { get; set; }
        public RegularUser RegularUser { get; set; } = null!;
        public int Seats { get; set; }
    }
}
