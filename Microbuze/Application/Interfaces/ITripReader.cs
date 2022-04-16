using System.Collections.Generic;
using Application.Models;

namespace Application.Interfaces
{
    public interface ITripReader
    {
        IEnumerable<TripDTO> GetFiltered(string departureLocation = "", string destination = "");
        TripDTO GetById(int id);
    }
}
