using System.Collections.Generic;
using Application.Domain;
using Application.Repository;
using Application.Utils;

namespace Application.Service
{
    public class TripService
    {
        private readonly ITripRepo repo;
        public TripService(ITripRepo repo) { this.repo = repo; }
        public List<Trip> GetTripsFiltered(string destination, string departureLocation)
            => repo.GetTripsFiltered(destination, departureLocation);
        public void Save(Trip trip) => repo.Save(trip);
        public void ExportToCsv(Trip trip)
        {
            var csvExporter = new CSVExporter();
            trip.Accept(csvExporter);
        }
        public void ExportToNaturalLanguage(Trip trip)
        {
            var txtExporter = new NaturalLanguageExporter();
            trip.Accept(txtExporter);
        }
    }
}
