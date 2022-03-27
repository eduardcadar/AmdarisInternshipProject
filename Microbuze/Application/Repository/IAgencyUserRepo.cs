using Application.Domain;

namespace Application.Repository
{
    public interface IAgencyUserRepo
    {
        public AgencyUser Get(int id);
    }
}
