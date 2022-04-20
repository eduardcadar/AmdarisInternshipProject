﻿using System.Threading.Tasks;
using Application.UseCases.Create;
using Application.UseCases.Find;
using Application.Services.Interfaces;
using System.Threading;
using Domain.Domain;
using Application.Models;

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

        public async Task<DRegularUser> CreateRegularUser(string username, string password, string phoneNumber,
            string firstName, string lastName, CancellationToken cancellationToken = default)
            => await _createRegularUser.Create(username, password, phoneNumber, firstName, lastName, cancellationToken);

        public async Task<RegularUserDTO> FindRegularUserById(int id, CancellationToken cancellationToken = default)
            => await _findRegularUserById.Find(id, cancellationToken);

        public async Task<DRegularUser> FindRegularUserByUsernameAndPassword(string username, string password,
            CancellationToken cancellationToken = default)
            => await _findRegularUser.Find(username, password, cancellationToken);
    }
}
