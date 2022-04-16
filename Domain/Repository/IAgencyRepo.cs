using Domain.Domain;

namespace Domain.Repository
{
    public interface IAgencyRepo
    {
        void Add(DAgency dAgency);
        DAgency GetByName(string agencyName);
    }
}
