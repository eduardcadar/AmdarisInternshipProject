using System;
using System.Text.RegularExpressions;

namespace Domain.Domain
{
    public class DRegularUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DRegularUser() { }
        public DRegularUser(string username, string phoneNumber, string firstName, string lastName)
        {
            Username = username;
            PhoneNumber = phoneNumber;
            FirstName = firstName;
            LastName = lastName;
            Validate();
        }
        internal void Validate()
        {
            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("Enter an username");
            if (Username.Trim().Length < 6)
                throw new ArgumentException("Username length cannot be less than 6");
            if (!Regex.IsMatch(PhoneNumber, @"^0[0-9]{9}$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(250)))
                throw new ArgumentException("Invalid phone number");
            if (string.IsNullOrWhiteSpace(FirstName))
                throw new ArgumentException("Enter a first name");
            if (string.IsNullOrWhiteSpace(LastName))
                throw new ArgumentException("Enter a last name");
        }

        public override string ToString()
        {
            return FirstName + " " + LastName;
        }
        public DReservation CreateReservation(DTrip trip, int seatsNumber)
            => new(trip, this, seatsNumber);
    }
}
