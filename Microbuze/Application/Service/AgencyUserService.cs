using Domain.Repository;
using Domain.Domain;

namespace Domain.Service
{
    public class AgencyUserService
    {
        private readonly IAgencyUserRepo _repo;
        public AgencyUserService(IAgencyUserRepo repo) { _repo = repo; }
        public DAgencyUser Get(int id) => _repo.Get(id);
    }
}
