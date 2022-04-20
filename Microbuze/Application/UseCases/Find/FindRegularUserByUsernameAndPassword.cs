using Domain.Domain;
using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Find
{
    public class FindRegularUserByUsernameAndPassword
    {
        private readonly IRegularUserRepo _regularUserRepo;

        public FindRegularUserByUsernameAndPassword(IRegularUserRepo repo)
        {
            _regularUserRepo = repo;
        }

        public async Task<DRegularUser> Find(string username, string password, CancellationToken cancellationToken = default)
            => await _regularUserRepo.GetByUsernameAndPassword(username, password, cancellationToken);
    }
}
