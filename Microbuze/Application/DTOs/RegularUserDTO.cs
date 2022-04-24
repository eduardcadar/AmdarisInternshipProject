namespace Application.DTOs
{
    public record RegularUserDTO
    {
        public int Id { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }
        public string PhoneNumber { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }
}