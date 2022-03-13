namespace Microbuze.domain
{
    public class RegularUser : User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RegularUser(int id, string username, string password, string phoneNumber, string firstName, string lastName)
            : base(id, username, password, phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
