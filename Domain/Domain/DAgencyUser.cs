using System;
using System.Text.RegularExpressions;

namespace Domain.Domain
{
    public class DAgencyUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public DAgency Agency { get; set; }
        public DAgencyUser(string username, string password, string phoneNumber, DAgency agency)
        {
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Agency = agency;
            Validate();
        }
        public DAgencyUser(int id, string username, string password, string phoneNumber, DAgency agency)
        {
            Id = id;
            Username = username;
            Password = password;
            PhoneNumber = phoneNumber;
            Agency = agency;
            Validate();
        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("Enter an username");
            if (string.IsNullOrWhiteSpace(Password))
                throw new ArgumentException("Enter a password");
            if (Password.Contains(" "))
                throw new ArgumentException("Password cannot contain spaces");
            if (Username.Trim().Length < 6)
                throw new ArgumentException("Username length cannot be less than 6");
            if (Password.Trim().Length < 6)
                throw new ArgumentException("Password length cannot be less than 6");
            if (!Regex.IsMatch(PhoneNumber, @"^0[0-9]{9}$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(250)))
                throw new ArgumentException("Invalid phone number");
            Agency.Validate();
        }
        public override string ToString()
        {
            return Agency.ToString();
        }
        public DTrip CreateTrip(string depLoc, string dest, DateTime depTime, TimeSpan duration, double price, int seats)
            => new (Agency, depLoc, dest, depTime, duration, price, seats);
    }
}
