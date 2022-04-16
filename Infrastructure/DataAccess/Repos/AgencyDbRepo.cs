using System;
using System.Linq;
using Domain.Domain;
using Domain.Repository;

namespace Infrastructure.DataAccess
{
    public class AgencyDbRepo : IAgencyRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DAgency GetByName(string agencyName)
        {
            var agency = _dbContext.Agencies.SingleOrDefault(a => a.AgencyName == agencyName);
            if (agency == null)
                throw new RepositoryException("No agency with this name");
            var dAgency = EntityUtils.AgencyToDAgency(agency);
            return dAgency;
        }

        public void Add(DAgency dAgency)
        {
            var agency = EntityUtils.DAgencytoAgency(dAgency);
            _dbContext.Agencies.Add(agency);
            _dbContext.SaveChanges();
        }
    }
}
