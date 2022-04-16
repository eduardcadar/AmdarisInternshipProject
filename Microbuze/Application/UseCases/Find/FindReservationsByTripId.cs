using System.Collections.Generic;
using Application.Interfaces;
using Application.Models;

namespace Application.UseCases.Find
{
    public class FindReservationsByTripId
    {
        private readonly IReservationReader _reader;

        public FindReservationsByTripId(IReservationReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<ReservationDTO> Find(int id)
            => _reader.GetByTripId(id);
    }
}
