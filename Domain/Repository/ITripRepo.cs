using System.Threading.Tasks;
using Domain.Domain;

namespace Domain.Repository
{
    public interface ITripRepo
    {
        void Add(DTrip dTrip);
    }
}
