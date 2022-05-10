using Application.DTOs;
using Application.Services.Interfaces;
using Application.UseCases.Create;
using Application.UseCases.Find;
using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AgencyUsersService : IAgencyUsersService
    {
        private readonly CreateAgencyUser _createAgencyUser;
        private readonly FindAgencyUserByUsernameAndPassword _findAgencyUser;
        private readonly FindAgencyUserById _findAgencyUserById;

        public AgencyUsersService(CreateAgencyUser createAgencyUser, FindAgencyUserByUsernameAndPassword findAgencyUser,
            FindAgencyUserById findAgencyUserById)
        {
            _createAgencyUser = createAgencyUser;
            _findAgencyUser = findAgencyUser;
            _findAgencyUserById = findAgencyUserById;
        }

        public async Task<DAgencyUser> CreateAgencyUser(string username, string password, string phoneNumber, int agencyId,
            CancellationToken cancellationToken = default)
            => await _createAgencyUser.Create(username, password, phoneNumber, agencyId, cancellationToken);

        public async Task<AgencyUserDTO> FindAgencyUserById(int id, CancellationToken cancellationToken = default)
            => await _findAgencyUserById.Find(id, cancellationToken);

        public async Task<DAgencyUser> FindAgencyUserByUsernameAndPassword(string username, string password,
            CancellationToken cancellationToken = default)
            => await _findAgencyUser.Find(username, password, cancellationToken);


    }
}
