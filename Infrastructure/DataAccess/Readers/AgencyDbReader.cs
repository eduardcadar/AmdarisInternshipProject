using Application.ReaderInterfaces;
using Application.Models;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess.Readers
{
    public class AgencyDbReader : IAgencyReader
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AgencyDTO> GetById(int id, CancellationToken cancellationToken = default)
        {
            var agency = await _dbContext.Agencies.SingleAsync(a => a.Id == id, cancellationToken);
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
