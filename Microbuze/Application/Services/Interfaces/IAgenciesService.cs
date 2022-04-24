using Application.DTOs;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAgenciesService
    {
        Task<AgencyDTO> CreateAgency(string agencyName, string phoneNumber, CancellationToken cancellationToken = default);
        Task<AgencyDTO> FindAgencyById(int id, CancellationToken cancellationToken = default);
    }
}
