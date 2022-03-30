using System;
using System.Text.RegularExpressions;
using Domain.Visitor;

namespace Application.Domain
{
    public class Agency : IVisitable
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public string PhoneNumber { get; set; }
        public Agency(string agencyName, string phoneNumber)
        {
            AgencyName = agencyName;
            PhoneNumber = phoneNumber;
            Validate();
        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(AgencyName))
                throw new ArgumentException("Enter an agency name");
            if (!Regex.IsMatch(PhoneNumber, @"^07[0-9]{8}$", RegexOptions.Compiled, TimeSpan.FromMilliseconds(250)))
                throw new ArgumentException("Invalid phone number");
        }
        public override string ToString()
        {
            return AgencyName + " " + PhoneNumber;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
