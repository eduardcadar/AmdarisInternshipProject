using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repos
{
    public class RegularUserDbRepo : IRegularUserRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public RegularUserDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<DRegularUser> Add(DRegularUser dRegularUser, CancellationToken cancellationToken = default)
        {
            var r = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Username.Equals(dRegularUser.Username), cancellationToken);
            if (r != null)
                throw new RepositoryException("There already exists a regular user with this username");
            var regularUser = EntityUtils.DRegularUserToRegularUser(dRegularUser);
            await _dbContext.RegularUsers.AddAsync(regularUser, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            dRegularUser.Id = regularUser.Id;
            return dRegularUser;
        }

        public async Task<DRegularUser> GetByUsername(string username, CancellationToken cancellationToken = default)
        {
            var regularUser = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Username.Equals(username), cancellationToken);
            if (regularUser == null)
                return null;
            var dRegularUser = EntityUtils.RegularUserToDRegularUser(regularUser);
            return dRegularUser;
        }
    }
}
