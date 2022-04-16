using System.Collections.Generic;
using Application.Interfaces;
using Application.Models;

namespace Application.UseCases.Find
{
    public class FindTripsFiltered
    {
        private readonly ITripReader _reader;

        public FindTripsFiltered(ITripReader reader)
        {
            _reader = reader;
        }

        public IEnumerable<TripDTO> Get(string departureLocation, string destination)
            => _reader.GetFiltered(departureLocation, destination);
    }
}
