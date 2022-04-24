using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.ReaderInterfaces;

namespace Application.UseCases.Find
{
    public class FindAgencyUserById
    {
        private readonly IAgencyUserReader _reader;

        public FindAgencyUserById(IAgencyUserReader reader)
        {
            _reader = reader;
        }

        public async Task<AgencyUserDTO> Find(int id, CancellationToken cancellationToken = default)
            => await _reader.GetById(id, cancellationToken);
    }
}
