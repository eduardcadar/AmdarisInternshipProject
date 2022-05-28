using System.Threading.Tasks;
using Application.UseCases.Create;
using Application.UseCases.Find;
using Application.Services.Interfaces;
using System.Threading;
using Domain.Domain;
using Application.DTOs;

namespace Application.Services
{
    public class RegularUsersService : IRegularUsersService
    {
        private readonly CreateRegularUser _createRegularUser;
        private readonly FindRegularUserByUsernameAndPassword _findRegularUser;
        private readonly FindRegularUserById _findRegularUserById;

        public RegularUsersService(CreateRegularUser createRegularUser, FindRegularUserByUsernameAndPassword findRegularUser,
            FindRegularUserById findRegularUserById)
        {
            _createRegularUser = createRegularUser;
            _findRegularUser = findRegularUser;
            _findRegularUserById = findRegularUserById;
        }

        public async Task<DRegularUser> CreateRegularUser(string regularUserId, string username, string phoneNumber,
            string firstName, string lastName, CancellationToken cancellationToken = default)
            => await _createRegularUser.Create(regularUserId, username, phoneNumber, firstName, lastName, cancellationToken);

        public async Task<RegularUserDTO> FindRegularUserById(string regularUserId, CancellationToken cancellationToken = default)
            => await _findRegularUserById.Find(regularUserId, cancellationToken);

        public async Task<DRegularUser> FindRegularUserByUsername(string username,
            CancellationToken cancellationToken = default)
            => await _findRegularUser.Find(username, cancellationToken);
    }
}
