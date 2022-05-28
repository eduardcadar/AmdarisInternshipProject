using System.Threading;
using System.Threading.Tasks;
using Domain.Domain;

namespace Domain.Repository
{
    public interface IReservationRepo
    {
        Task<DReservation> Add(DReservation dReservation, CancellationToken cancellationToken = default);
        Task Delete(int tripId, string regularUserId, CancellationToken cancellationToken = default);
        Task Update(int tripId, string regularUserId, int seats, CancellationToken cancellationToken = default);
    }
}
