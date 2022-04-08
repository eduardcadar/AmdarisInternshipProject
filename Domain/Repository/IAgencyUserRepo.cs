using Domain.Domain;

namespace Domain.Repository
{
    public interface IAgencyUserRepo
    {
        public DAgencyUser Get(int id);
        public void Save(DAgencyUser dAgencyUser);
    }
}
