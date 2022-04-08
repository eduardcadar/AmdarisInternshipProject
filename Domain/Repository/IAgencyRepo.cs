using Domain.Domain;

namespace Domain.Repository
{
    public interface IAgencyRepo
    {
        public void Save(DAgency dAgency);
        public DAgency Get(int id);
    }
}
