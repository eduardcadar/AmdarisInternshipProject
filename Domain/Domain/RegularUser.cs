using System;

namespace Application.Domain
{
    public class RegularUser
    {
        public int Id { get; set; }
        public User User { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RegularUser(User user, string firstName, string lastName)
        {
            this.User = user;
            this.FirstName = firstName;
            this.LastName = lastName;
            Validate();
        }
        public void Validate()
        {
            this.User.Validate();
            if (string.IsNullOrWhiteSpace(this.FirstName))
                throw new ArgumentException("Enter a first name");
            if (string.IsNullOrWhiteSpace(this.LastName))
                throw new ArgumentException("Enter a last name");
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}
