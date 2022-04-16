using System.Linq;
using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    public class AgencyUserDbRepo : IAgencyUserRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyUserDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DAgencyUser GetByUsernameAndPassword(string username, string password)
        {
            var agencyUser = _dbContext.AgencyUsers
                .SingleOrDefault(a => a.Username.Equals(username) && a.Password.Equals(password));
            if (agencyUser == null)
                throw new RepositoryException("Wrong username or password");
            var dAgencyUser = EntityUtils.AgencyUserToDAgencyUser(agencyUser);
            return dAgencyUser;

        }

        public void Add(DAgencyUser dAgencyUser)
        {
            var agencyUser = EntityUtils.DAgencyUserToAgencyUser(dAgencyUser);
            _dbContext.AgencyUsers.Add(agencyUser);
            _dbContext.SaveChanges();
        }
    }
}
