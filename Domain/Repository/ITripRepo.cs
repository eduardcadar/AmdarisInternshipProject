using System.Collections.Generic;
using Domain.Domain;

namespace Domain.Repository
{
    public interface ITripRepo
    {
        public void Save(DTrip dTrip);
        public void Delete(DTrip dTrip);
        public DTrip Get(int id);
        public IEnumerable<DTrip> GetFiltered(string destination = "", string departureLocation = "");
    }
}
