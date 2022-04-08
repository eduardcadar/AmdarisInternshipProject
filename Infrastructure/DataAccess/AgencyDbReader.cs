using System.Collections.Generic;
using System.Linq;
using Domain.Interfaces;
using Domain.Models;

namespace Infrastructure.DataAccess
{
    public class AgencyDbReader : IAgencyReader
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AgencyDTO> ReadAll()
        {
            var agencyEntities = _dbContext.Agencies.ToList();
            return agencyEntities.Select(a => new AgencyDTO {
                Id = a.Id,
                AgencyName = a.AgencyName,
                PhoneNumber = a.PhoneNumber
            });
        }
    }
}
