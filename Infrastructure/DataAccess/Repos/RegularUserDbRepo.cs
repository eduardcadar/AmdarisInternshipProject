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
        }

        public async Task<DRegularUser> Add(DRegularUser dRegularUser, CancellationToken cancellationToken = default)
        {
            var regularUser = EntityUtils.DRegularUserToRegularUser(dRegularUser);
            await _dbContext.RegularUsers.AddAsync(regularUser, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            dRegularUser.Id = regularUser.Id;
            return dRegularUser;
        }

        public async Task<DRegularUser> GetByUsernameAndPassword(string username, string password, CancellationToken cancellationToken = default)
        {
            var regularUser = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Username.Equals(username) && r.Password.Equals(password), cancellationToken);
            if (regularUser == null)
                throw new RepositoryException("Wrong username or password");
            var dRegularUser = EntityUtils.RegularUserToDRegularUser(regularUser);
            return dRegularUser;
        }
    }
}
