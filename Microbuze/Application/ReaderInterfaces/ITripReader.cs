using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.ReaderInterfaces
{
    public interface ITripReader
    {
        Task<IEnumerable<TripDTO>> GetFiltered(
            string departureLocation = "", string destination = "", CancellationToken cancellationToken = default);
        Task<TripDTO> GetById(int id, CancellationToken cancellationToken = default);
    }
}
