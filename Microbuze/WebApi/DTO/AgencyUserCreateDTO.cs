namespace Api.DTO
{
    public record AgencyUserCreateDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public int AgencyId { get; set; }
    }
}
