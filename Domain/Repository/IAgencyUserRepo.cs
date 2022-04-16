using Domain.Domain;

namespace Domain.Repository
{
    public interface IAgencyUserRepo
    {
        DAgencyUser GetByUsernameAndPassword(string username, string password);
        void Add(DAgencyUser dAgencyUser);
    }
}
