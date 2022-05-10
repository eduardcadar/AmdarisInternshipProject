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
            int agencyId, CancellationToken cancellationToken = default)
        {
            var dAgencyUser = new DAgencyUser(username, password, phoneNumber, new DAgency { Id = agencyId });
            return await _agencyUserRepo.Add(dAgencyUser, cancellationToken);
        }
    }
}
