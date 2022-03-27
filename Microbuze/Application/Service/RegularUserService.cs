using Application.Repository;
using Application.Domain;

namespace Application.Service
{
    public class RegularUserService
    {
        private readonly IRegularUserRepo repo;
        public RegularUserService(IRegularUserRepo repo) { this.repo = repo; }
        public RegularUser Get(int id) => repo.Get(id);
    }
}
