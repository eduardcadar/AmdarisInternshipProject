namespace Api.DTO
{
    public record ReservationCreateDTO
    {
        public int TripId { get; set; }
        public int RegularUserId { get; set; }
        public int Seats { get; set; }
    }
}
