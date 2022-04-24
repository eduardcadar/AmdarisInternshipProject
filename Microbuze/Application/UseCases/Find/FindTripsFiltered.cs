using System.Collections.Generic;
using Application.ReaderInterfaces;
using Application.DTOs;
using System.Threading.Tasks;
using System.Threading;

namespace Application.UseCases.Find
{
    public class FindTripsFiltered
    {
        private readonly ITripReader _tripReader;

        public FindTripsFiltered(ITripReader reader)
        {
            _tripReader = reader;
        }

        public async Task<IEnumerable<TripDTO>> Find(string departureLocation, string destination, CancellationToken cancellationToken = default)
            => await _tripReader.GetFiltered(departureLocation, destination, cancellationToken);
    }
}
