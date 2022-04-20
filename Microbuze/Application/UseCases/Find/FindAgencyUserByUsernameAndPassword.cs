using Domain.Domain;
using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Find
{
    public class FindAgencyUserByUsernameAndPassword
    {
        private readonly IAgencyUserRepo _agencyUserRepo;

        public FindAgencyUserByUsernameAndPassword(IAgencyUserRepo repo)
        {
            _agencyUserRepo = repo;
        }

        public async Task<DAgencyUser> Find(string username, string password, CancellationToken cancellationToken = default)
            => await _agencyUserRepo.GetByUsernameAndPassword(username, password, cancellationToken);
    }
}
