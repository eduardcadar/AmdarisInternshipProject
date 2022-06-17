using Application.DTOs;
using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAgencyUsersService
    {
        Task CheckFields(string username, string phoneNumber, string agency,
            CancellationToken cancellationToken = default);
        Task<DAgencyUser> CreateAgencyUser(string id, string username, string phoneNumber, string agency,
            CancellationToken cancellationToken = default);
        Task<DAgencyUser> FindAgencyUserByUsername(string username,
            CancellationToken cancellationToken = default);
        Task<AgencyUserDTO> FindAgencyUserById(string agencyUserId, CancellationToken cancellationToken = default);
    }
}
