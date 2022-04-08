using Domain.Domain;
using Domain.Repository;
using Infrastructure.Persistence.Entities;

namespace Infrastructure.DataAccess
{
    public class AgencyDbRepo : IAgencyRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DAgency Get(int id)
        {
            var agency = _dbContext.Agencies.Find(id);
            if (agency == null)
                throw new RepositoryException("There is no Agency with this id");
            var dAgency = EntityUtils.AgencyToDAgency(agency);
            return dAgency;
        }

        public void Save(DAgency dAgency)
        {
            var agency = EntityUtils.DAgencytoAgency(dAgency);
            _dbContext.Agencies.Add(agency);
            _dbContext.SaveChanges();
        }
    }
}
