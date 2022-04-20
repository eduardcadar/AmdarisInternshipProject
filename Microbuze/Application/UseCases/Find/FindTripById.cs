using Application.Models;
using Application.ReaderInterfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Find
{
    public class FindTripById
    {
        private readonly ITripReader _tripReader;

        public FindTripById(ITripReader tripReader)
        {
            _tripReader = tripReader;
        }

        public async Task<TripDTO> Find(int id, CancellationToken cancellationToken = default)
            => await _tripReader.GetById(id, cancellationToken);
    }
}
