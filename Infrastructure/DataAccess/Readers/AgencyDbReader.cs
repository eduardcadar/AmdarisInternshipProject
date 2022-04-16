using System.Collections.Generic;
using System.Linq;
using Application.Interfaces;
using Application.Models;

namespace Infrastructure.DataAccess
{
    public class AgencyDbReader : IAgencyReader
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AgencyDTO GetById(int id)
        {
            var agency = _dbContext.Agencies.Single(a => a.Id == id);
            var agencyDto = new AgencyDTO
            {
                Id = agency.Id,
                AgencyName = agency.AgencyName,
                PhoneNumber = agency.PhoneNumber
            };
            return agencyDto;
        }
    }
}
