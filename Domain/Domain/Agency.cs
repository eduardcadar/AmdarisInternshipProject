using System;

namespace Domain.Domain
{
    public class Agency
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public Agency(string agencyName)
        {
            this.AgencyName = agencyName;
            Validate();
        }
        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(this.AgencyName))
                throw new ArgumentException("Enter an agency name");
        }
        public override string ToString()
        {
            return this.AgencyName;
        }
    }
}
