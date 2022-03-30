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
            User = user;
            FirstName = firstName;
            LastName = lastName;
            Validate();
        }
        public void Validate()
        {
            User.Validate();
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("Enter a first name");
            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("Enter a last name");
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
    }
}
