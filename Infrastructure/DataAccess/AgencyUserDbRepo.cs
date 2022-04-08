using System;
using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    class AgencyUserDbRepo : IAgencyUserRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyUserDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DAgencyUser Get(int id)
        {
            var agencyUser = _dbContext.AgencyUsers.Find(id);
            if (agencyUser == null)
                throw new RepositoryException("There is no AgencyUser with this id");
            var dAgencyUser = EntityUtils.AgencyUserToDAgencyUser(agencyUser);
            return dAgencyUser;
        }

        public void Save(DAgencyUser dAgencyUser)
        {
            var agencyUser = EntityUtils.DAgencyUserToAgencyUser(dAgencyUser);
            _dbContext.AgencyUsers.Add(agencyUser);
            _dbContext.SaveChanges();
        }
    }
}
