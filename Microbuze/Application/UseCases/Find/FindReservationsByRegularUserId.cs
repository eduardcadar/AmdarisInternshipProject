using System.Collections.Generic;
using Application.ReaderInterfaces;
using Application.DTOs;
using System.Threading.Tasks;
using System.Threading;

namespace Application.UseCases.Find
{
    public class FindReservationsByRegularUserId
    {

        private readonly IReservationReader _reservationReader;

        public FindReservationsByRegularUserId(IReservationReader reader)
        {
            _reservationReader = reader;
        }

        public async Task<IEnumerable<ReservationDTO>> Find(string id, CancellationToken cancellationToken = default)
            => await _reservationReader.GetByRegularUserId(id, cancellationToken);
    }
}
