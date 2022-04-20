using Application.Models;
using Application.ReaderInterfaces;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DataAccess.Readers
{
    public class RegularUserDbReader : IRegularUserReader
    {
        private readonly MicrobuzeContext _dbContext;

        public RegularUserDbReader(MicrobuzeContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<RegularUserDTO> GetById(int id, CancellationToken cancellationToken = default)
        {

            var regularUser = await _dbContext.RegularUsers
                .SingleOrDefaultAsync(r => r.Id.Equals(id), cancellationToken);
            if (regularUser == null)
                throw new RepositoryException("Wrong regularUser id");
            var regularUserDto = EntityUtils.RegularUserToRegularUserDTO(regularUser);
            return regularUserDto;
        }
    }
}
