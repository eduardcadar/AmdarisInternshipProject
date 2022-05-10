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

        public async Task<DAgencyUser> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken)
        {
            var agencyUser = await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Username.Equals(username) && a.Password.Equals(password), cancellationToken);
            if (agencyUser == null)
                return null;
            agencyUser.Agency = await _dbContext.Agencies
                .SingleOrDefaultAsync(a => a.Id.Equals(agencyUser.AgencyId), cancellationToken);
            var dAgencyUser = EntityUtils.AgencyUserToDAgencyUser(agencyUser);
            return dAgencyUser;
        }

        public async Task<DAgencyUser> Add(DAgencyUser dAgencyUser, CancellationToken cancellationToken)
        {
            var agencyUser = EntityUtils.DAgencyUserToAgencyUser(dAgencyUser);
            agencyUser.Agency = null;
            await _dbContext.AgencyUsers.AddAsync(agencyUser, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            dAgencyUser.Id = agencyUser.Id;
            dAgencyUser.Agency = EntityUtils.AgencyToDAgency(await _dbContext.Agencies
                .SingleOrDefaultAsync(a => a.Id.Equals(agencyUser.AgencyId), cancellationToken));
            return dAgencyUser;
        }
    }
}
