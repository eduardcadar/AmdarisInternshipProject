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

        public async Task<DAgencyUser> Create(string id, string username, string phoneNumber,
            string agency, CancellationToken cancellationToken = default)
        {
            var dAgencyUser = new DAgencyUser(username, phoneNumber, agency)
            {
                Id = id
            };
            return await _agencyUserRepo.Add(dAgencyUser, cancellationToken);
        }
    }
}
