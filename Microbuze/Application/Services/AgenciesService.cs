using Application.DTOs;
using Application.Services.Interfaces;
using Application.UseCases.Create;
using Application.UseCases.Find;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AgenciesService : IAgenciesService
    {
        private readonly CreateAgency _createAgency;
        private readonly FindAgencyById _findAgencyById;

        public AgenciesService(CreateAgency createAgency, FindAgencyById findAgencyById)
        {
            _createAgency = createAgency;
            _findAgencyById = findAgencyById;
        }

        public async Task<AgencyDTO> CreateAgency(string agencyName, string phoneNumber, CancellationToken cancellationToken = default)
        {
            var createdAgency = await _createAgency.Create(agencyName, phoneNumber, cancellationToken);
            return createdAgency;
        }

        public async Task<AgencyDTO> FindAgencyById(int id, CancellationToken cancellationToken = default)
        {
            var agencyDto = await _findAgencyById.Find(id, cancellationToken);
            return agencyDto;
        }
    }
}
