using Domain.Repository;
using Domain.Domain;

namespace Domain.Service
{
    public class RegularUserService
    {
        private readonly IRegularUserRepo _repo;
        public RegularUserService(IRegularUserRepo repo) { _repo = repo; }
        public DRegularUser Get(int id) => _repo.Get(id);
    }
}
