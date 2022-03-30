using System;
using System.Text.RegularExpressions;

namespace Application.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public User(string username, string password, string phoneNumber)
        {
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Validate();
        }
        public void Validate()
        {
            if (Username.Length < 6)
                throw new ArgumentException("Username length cannot be less than 6");
            if (Password.Length < 6)
                throw new ArgumentException("Password length cannot be less than 6");
            if (!Regex.IsMatch(PhoneNumber, @"^07[0-9]{8}$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(250)))
                throw new ArgumentException("Invalid phone number");
        }
        public Reservation CreateReservation(Trip trip, int seatsNumber)
            => new (trip, this, seatsNumber);
    }
}