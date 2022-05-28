namespace Api.DTO
{
    public record AgencyUserCreateDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Agency { get; set; }
    }
}
