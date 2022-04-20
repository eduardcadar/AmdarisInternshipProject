using Application.Models;
using Domain.Domain;
using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Create
{
    public class CreateAgency
    {
        private readonly IAgencyRepo _agencyRepo;

        public CreateAgency(IAgencyRepo repo)
        {
            _agencyRepo = repo;
        }

        public async Task<AgencyDTO> Create(string agencyName, string phoneNumber, CancellationToken cancellationToken = default)
        {
            var dAgency = new DAgency(agencyName, phoneNumber);
            var createdAgency = await _agencyRepo.Add(dAgency, cancellationToken);
            var agencyDto = new AgencyDTO {
                Id = createdAgency.Id,
                AgencyName = agencyName,
                PhoneNumber = phoneNumber
            };
            return agencyDto;
        }
    }
}
