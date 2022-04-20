using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;

namespace Domain.Repository
{
    public interface IReservationRepo
    {
        Task Add(DReservation dReservation, CancellationToken cancellationToken = default);
        Task Delete(DReservation dReservation, CancellationToken cancellationToken = default);
        Task Update(DReservation dReservation, CancellationToken cancellationToken = default);
    }
}
