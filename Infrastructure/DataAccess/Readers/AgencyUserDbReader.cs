using Application.DTOs;
using Application.ReaderInterfaces;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Readers
{
    public class AgencyUserDbReader : IAgencyUserReader
    {
        private readonly MicrobuzeContext _dbContext;

        public AgencyUserDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
            _dbContext.Database.EnsureCreated();
        }

        public async Task<AgencyUserDTO> GetById(int id, CancellationToken cancellationToken = default)
        {
            var agencyUser = await _dbContext.AgencyUsers
                .SingleOrDefaultAsync(a => a.Id.Equals(id), cancellationToken);
            if (agencyUser == null)
                return null;
            agencyUser.Agency = await _dbContext.Agencies
                .SingleOrDefaultAsync(a => a.Id.Equals(agencyUser.AgencyId), cancellationToken);
            var agencyUserDto = EntityUtils.AgencyUserToAgencyUserDTO(agencyUser);
            return agencyUserDto;
        }
    }
}
