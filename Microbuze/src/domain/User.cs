namespace Microbuze.src.domain
{
    public abstract class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public User(int id, string username, string password, string phoneNumber)
        {
            Id = id;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
        }
    }
}
