namespace Domain.Domain
{
    public class RegularUser
    {
        public User User { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RegularUser(int id, string username, string password, string phoneNumber, string firstName, string lastName)
        {
            this.User = new User(id, username, password, phoneNumber);
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
