using Application.DTOs;
using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IRegularUsersService
    {
        Task<DRegularUser> CreateRegularUser(string regularUserId, string username, string phoneNumber,
            string firstName, string lastName, CancellationToken cancellationToken = default);
        Task<DRegularUser> FindRegularUserByUsername(string username,
            CancellationToken cancellationToken = default);
        Task<RegularUserDTO> FindRegularUserById(string regularUserId, CancellationToken cancellationToken = default);
        Task CheckFields(string userName, string phoneNumber, string firstName, string lastName, CancellationToken cancellationToken);
    }
}
