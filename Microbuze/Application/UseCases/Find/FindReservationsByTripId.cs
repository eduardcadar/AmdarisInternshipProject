using System.Collections.Generic;
using Application.ReaderInterfaces;
using Application.Models;
using System.Threading.Tasks;
using System.Threading;

namespace Application.UseCases.Find
{
    public class FindReservationsByTripId
    {
        private readonly IReservationReader _reservationReader;

        public FindReservationsByTripId(IReservationReader reader)
        {
            _reservationReader = reader;
        }

        public async Task<IEnumerable<ReservationDTO>> Find(int id, CancellationToken cancellationToken = default)
            => await _reservationReader.GetByTripId(id, cancellationToken);
    }
}
