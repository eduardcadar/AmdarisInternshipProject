using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Repos
{
    public class AgencyDbRepo : IAgencyRepo
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyDbRepo(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DAgency> GetByName(string agencyName, CancellationToken cancellationToken = default)
        {
            var agency = await _dbContext.Agencies.SingleOrDefaultAsync(a => a.AgencyName == agencyName, cancellationToken);
            if (agency == null)
                throw new RepositoryException("No agency with this name");
            var dAgency = EntityUtils.AgencyToDAgency(agency);
            return dAgency;
        }

        public async Task<DAgency> Add(DAgency dAgency, CancellationToken cancellationToken = default)
        {
            var agency = EntityUtils.DAgencytoAgency(dAgency);
            await _dbContext.Agencies.AddAsync(agency, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            dAgency.Id = agency.Id;
            return dAgency;
        }
    }
}
