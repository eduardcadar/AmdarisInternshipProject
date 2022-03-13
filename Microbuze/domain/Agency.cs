namespace Microbuze.domain
{
    public class Agency
    {
        public string AgencyName { get; set; }
        public Agency(string agencyName)
        { 
            this.AgencyName = agencyName;
        }
        public override string ToString()
        {
            return this.AgencyName;
        }
    }
}
