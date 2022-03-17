namespace Microbuze.src.domain
{
    public class Agency
    {
        public int Id { get; set; }
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
