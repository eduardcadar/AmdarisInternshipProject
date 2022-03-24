namespace Domain.Domain
{
    public class AgencyUser
    {
        public User User { get; }
        public Agency Agency { get; }
        public AgencyUser(int id, string username, string password, string phoneNumber, Agency agency)
        {
            this.User = new User(id, username, password, phoneNumber);
            this.Agency = agency;
        }
        public override string ToString()
        {
            return this.Agency.ToString();
        }
    }
}
