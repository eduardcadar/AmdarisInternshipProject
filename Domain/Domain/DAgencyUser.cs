using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Domain
{
    public class DAgencyUser
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string PhoneNumber { get; set; }
        public string Agency { get; set; }
        public DAgencyUser() { }
        public DAgencyUser(string username, string phoneNumber, string agency)
        {
            Username = username;
            PhoneNumber = phoneNumber;
            Agency = agency;
            Validate();
        }
        internal void Validate()
        {
            if (string.IsNullOrWhiteSpace(Username))
                throw new ArgumentException("Enter an username");
            if (Username.Trim().Length < 6)
                throw new ArgumentException("Username length cannot be less than 6");
            if (string.IsNullOrWhiteSpace(Agency))
                throw new ArgumentException("Enter an agency");
            if (!Regex.IsMatch(PhoneNumber, @"^0[0-9]{9}$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(250)))
                throw new ArgumentException("Invalid phone number");
        }

        public async static Task Validate(string username, string phoneNumber, string agency,
            CancellationToken cancellationToken = default)
        {
            await Task.Run(() => { }, cancellationToken);
            if (string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Enter an username");
            if (username.Trim().Length < 6)
                throw new ArgumentException("Username length cannot be less than 6");
            if (string.IsNullOrWhiteSpace(agency))
                throw new ArgumentException("Enter an agency");
            if (!Regex.IsMatch(phoneNumber, @"^0[0-9]{9}$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(250)))
                throw new ArgumentException("Invalid phone number");
        }

        public override string ToString()
        {
            return Agency;
        }

        public DTrip CreateTrip(string depLoc, string dest, DateTime depTime, TimeSpan duration, double price, int seats)
            => new (this, depLoc, dest, depTime, duration, price, seats);
    }
}
