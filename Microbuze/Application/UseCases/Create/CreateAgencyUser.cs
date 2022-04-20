using Domain.Domain;
using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Create
{
    public class CreateAgencyUser
    {
        private readonly IAgencyUserRepo _agencyUserRepo;

        public CreateAgencyUser(IAgencyUserRepo repo)
        {
            _agencyUserRepo = repo;
        }

        public async Task<DAgencyUser> Create(string username, string password, string phoneNumber,
            DAgency dAgency, CancellationToken cancellationToken = default)
        {
            var dAgencyUser = new DAgencyUser(username, password, phoneNumber, dAgency);
            return await _agencyUserRepo.Add(dAgencyUser, cancellationToken);
        }
    }
}
