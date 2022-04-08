using System.Collections.Generic;
using Domain.Domain;
using Domain.Repository;
using Domain.Utils;

namespace Domain.Service
{
    public class TripService
    {
        private readonly ITripRepo _repo;
        private readonly IAgencyUserRepo _agencyUserRepo;
        public TripService(ITripRepo repo) { _repo = repo; }
        public IEnumerable<DTrip> GetFiltered(string destination, string departureLocation)
            => _repo.GetFiltered(destination, departureLocation);
        public void Save(int userId)
        {
            var agencyUser = _agencyUserRepo.Get(userId);
            //var trip = agencyUser.CreateTrip(...);
            //_repo.Save(trip);
        }




        public void ExportToCsv(DTrip trip)
        {
            var csvExporter = new CSVExporter();
            trip.Accept(csvExporter);
        }
        public void ExportToNaturalLanguage(DTrip trip)
        {
            var txtExporter = new NaturalLanguageExporter();
            trip.Accept(txtExporter);
        }
    }
}
