namespace Api.DTO
{
    public record RegularUserCreateDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
