using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;

namespace Domain.Repository
{
    public interface IReservationRepo
    {
        Task<DReservation> Add(DReservation dReservation, CancellationToken cancellationToken = default);
        Task Delete(int tripId, int regularUserId, CancellationToken cancellationToken = default);
        Task Update(int tripId, int regularUserId, int seats, CancellationToken cancellationToken = default);
    }
}
