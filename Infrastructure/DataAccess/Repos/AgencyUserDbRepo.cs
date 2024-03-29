﻿using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repos
{
    public class AgencyUserDbRepo : IAgencyUserRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyUserDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<DAgencyUser> Add(DAgencyUser dAgencyUser, CancellationToken cancellationToken)
        {
            var a = await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Username.Equals(dAgencyUser.Username), cancellationToken);
            if (a != null)
                throw new RepositoryException("There already is an agency user with this username");
            var agencyUser = EntityUtils.DAgencyUserToAgencyUser(dAgencyUser);
            await _dbContext.AgencyUsers.AddAsync(agencyUser, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            dAgencyUser.Id = agencyUser.Id;
            return dAgencyUser;
        }

        public async Task<DAgencyUser> GetByUsername(string username, CancellationToken cancellationToken)
        {
            var agencyUser = await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Username.Equals(username), cancellationToken);
            if (agencyUser == null)
                return null;
            var dAgencyUser = EntityUtils.AgencyUserToDAgencyUser(agencyUser);
            return dAgencyUser;
        }
    }
}
