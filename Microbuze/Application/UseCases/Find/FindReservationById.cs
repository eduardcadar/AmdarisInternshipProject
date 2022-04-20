using Application.Models;
using Application.ReaderInterfaces;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Find
{
    public class FindReservationById
    {
        private readonly IReservationReader _reader;

        public FindReservationById(IReservationReader reader)
        {
            _reader = reader;
        }

        public async Task<ReservationDTO> Find(int userId, int tripId, CancellationToken cancellationToken = default)
            => await _reader.GetById(userId, tripId, cancellationToken);
    }
}
