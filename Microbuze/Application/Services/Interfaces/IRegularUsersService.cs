using Application.Models;
using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IRegularUsersService
    {
        Task<DRegularUser> CreateRegularUser(string username, string password, string phoneNumber,
            string firstName, string lastName, CancellationToken cancellationToken = default);
        Task<DRegularUser> FindRegularUserByUsernameAndPassword(string username, string password,
            CancellationToken cancellationToken = default);
        Task<RegularUserDTO> FindRegularUserById(int id, CancellationToken cancellationToken = default);
    }
}
