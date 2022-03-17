using System;

namespace Microbuze.src.domain
{
    public class Trip
    {
        public int Id { get; set; }
        public Agency Agency { get; set; }
        public string DepartureLocation { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public TimeSpan Duration { get; set; }
        public Trip(Agency agency, string departureLocation, string destination, DateTime departureTime, TimeSpan duration)
        {
            this.Agency = agency;
            this.DepartureLocation = departureLocation;
            this.Destination = destination;
            this.DepartureTime = departureTime;
            this.Duration = duration;
        }
        public override string ToString()
        {
            return this.DepartureLocation + " --> " + this.Destination + " on " + DepartureTime.ToString();
        }
    }
}
