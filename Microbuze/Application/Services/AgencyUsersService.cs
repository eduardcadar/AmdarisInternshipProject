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

        public async Task CheckFields(string username, string phoneNumber, string agency, CancellationToken cancellationToken = default)
            => await DAgencyUser.Validate(username, phoneNumber, agency, cancellationToken);

        public async Task<DAgencyUser> CreateAgencyUser(string id, string username, string phoneNumber, string agency,
            CancellationToken cancellationToken = default)
            => await _createAgencyUser.Create(id, username, phoneNumber, agency, cancellationToken);

        public async Task<AgencyUserDTO> FindAgencyUserById(string id, CancellationToken cancellationToken = default)
            => await _findAgencyUserById.Find(id, cancellationToken);

        public async Task<DAgencyUser> FindAgencyUserByUsername(string username,
            CancellationToken cancellationToken = default)
            => await _findAgencyUser.Find(username, cancellationToken);


    }
}
