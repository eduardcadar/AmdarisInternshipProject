using System.Collections.Generic;
using Application.Interfaces;
using Application.Models;

namespace Application.UseCases.Find
{
    public class FindReservationsByRegularUserId
    {

        private readonly IReservationReader _reader;

        public FindReservationsByRegularUserId(IReservationReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<ReservationDTO> Find(int id)
            => _reader.GetByRegularUserId(id);
    }
}
