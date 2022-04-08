using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    class RegularUserDbRepo : IRegularUserRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public RegularUserDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DRegularUser Get(int id)
        {
            var regularUser = _dbContext.RegularUsers.Find(id);
            if (regularUser == null)
                throw new RepositoryException("There is not RegularUser with this id");
            var dRegularUser = EntityUtils.RegularUserToDRegularUser(regularUser);
            return dRegularUser;
        }
    }
}
