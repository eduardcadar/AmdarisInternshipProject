using Application.DTOs;
using Application.ReaderInterfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Find
{
    public class FindAgencyById
    {
        private readonly IAgencyReader _agencyReader;

        public FindAgencyById(IAgencyReader agencyReader)
        {
            _agencyReader = agencyReader;
        }

        public async Task<AgencyDTO> Find(int id, CancellationToken cancellationToken = default)
        {
            var agencyDto = await _agencyReader.GetById(id, cancellationToken);
            return agencyDto;
        }
    }
}
