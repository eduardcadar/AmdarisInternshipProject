namespace Application.DTOs
{
    public record ReservationDTO
    {
        public TripDTO Trip { get; set; }
        public RegularUserDTO RegularUser { get; set; }
        public int Seats { get; set; }
    }
}
