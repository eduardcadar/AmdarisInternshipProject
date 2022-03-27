using Application.Repository;
using Application.Domain;

namespace Application.Service
{
    public class AgencyUserService
    {
        private readonly IAgencyUserRepo repo;
        public AgencyUserService(IAgencyUserRepo repo) { this.repo = repo; }
        public AgencyUser Get(int id) => this.repo.Get(id);
    }
}
