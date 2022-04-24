namespace Application.DTOs
{
    public record ReservationDTO
    {
        public TripDTO Trip { get; init; }
        public RegularUserDTO RegularUser { get; init; }
        public int Seats { get; init; }
    }
}
