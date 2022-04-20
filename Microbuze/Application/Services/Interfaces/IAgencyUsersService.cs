﻿using Application.Models;
using Domain.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Interfaces
{
    public interface IAgencyUsersService
    {
        Task<DAgencyUser> CreateAgencyUser(string username, string password, string phoneNumber, DAgency dAgency,
            CancellationToken cancellationToken = default);
        Task<DAgencyUser> FindAgencyUserByUsernameAndPassword(string username, string password,
            CancellationToken cancellationToken = default);
        Task<AgencyUserDTO> FindAgencyUserById(int id, CancellationToken cancellationToken = default);
    }
}
