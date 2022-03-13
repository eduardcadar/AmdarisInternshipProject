namespace Microbuze.domain
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public User(int id, string username, string password, string phoneNumber)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.PhoneNumber = phoneNumber;
        }
    }
}
