using System.Linq;
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
        }

        public async Task<DAgencyUser> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken)
        {
            var agencyUser = await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Username.Equals(username) && a.Password.Equals(password), cancellationToken);
            if (agencyUser == null)
                throw new RepositoryException("Wrong username or password");
            var dAgencyUser = EntityUtils.AgencyUserToDAgencyUser(agencyUser);
            return dAgencyUser;

        }

        public async Task<DAgencyUser> Add(DAgencyUser dAgencyUser, CancellationToken cancellationToken)
        {
            var agencyUser = EntityUtils.DAgencyUserToAgencyUser(dAgencyUser);
            await _dbContext.AgencyUsers.AddAsync(agencyUser, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            dAgencyUser.Id = agencyUser.Id;
            return dAgencyUser;
        }
    }
}
