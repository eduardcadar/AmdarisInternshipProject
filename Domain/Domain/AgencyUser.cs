using System;

namespace Application.Domain
{
    public class AgencyUser
    {
        public int Id { get; set; }
        public User User { get; }
        public Agency Agency { get; }
        public AgencyUser(User user, Agency agency)
        {
            this.User = user;
            this.Agency = agency;
            Validate();
        }
        public void Validate()
        {
            this.User.Validate();
            this.Agency.Validate();
        }
        public override string ToString()
        {
            return this.Agency.ToString();
        }
        public Trip CreateTrip(string depLoc, string dest, DateTime depTime, TimeSpan duration, float price, int seats)
            => new (this.Agency, depLoc, dest, depTime, duration, price, seats);
    }
}
