using System;
using System.Linq;
using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    public class RegularUserDbRepo : IRegularUserRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public RegularUserDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(DRegularUser dRegularUser)
        {
            var regularUser = EntityUtils.DRegularUserToRegularUser(dRegularUser);
            _dbContext.RegularUsers.Add(regularUser);
            _dbContext.SaveChanges();
        }

        public DRegularUser GetByUsernameAndPassword(string username, string password)
        {
            var regularUser = _dbContext.RegularUsers
                .SingleOrDefault(r => r.Username.Equals(username) && r.Password.Equals(password));
            if (regularUser == null)
                throw new RepositoryException("Wrong username or password");
            var dRegularUser = EntityUtils.RegularUserToDRegularUser(regularUser);
            return dRegularUser;
        }
    }
}
