namespace Api.DTO
{
    public record TripCreateDTO
    {
        public string AgencyUserId { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public string DepartureTime { get; set; }
        public string Duration { get; set; }
        public double Price { get; set; }
        public int Seats { get; set; }
    }
}
