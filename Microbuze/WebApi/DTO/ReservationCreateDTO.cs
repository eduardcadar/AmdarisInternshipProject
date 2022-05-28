namespace Api.DTO
{
    public record ReservationCreateDTO
    {
        public int TripId { get; set; }
        public string RegularUserId { get; set; }
        public int Seats { get; set; }
    }
}
