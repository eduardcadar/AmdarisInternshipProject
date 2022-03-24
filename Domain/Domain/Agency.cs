using System;

namespace Domain.Domain
{
    public class Agency
    {
        public int Id { get; set; }
        public string AgencyName { get; set; }
        public Agency(string agencyName)
        {
            if (agencyName == "")
                throw new ArgumentException("Write an agency name");
            this.AgencyName = agencyName;
        }
        public override string ToString()
        {
            return this.AgencyName;
        }
    }
}
