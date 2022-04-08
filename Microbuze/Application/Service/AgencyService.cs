using System.Collections.Generic;
using Domain.Domain;
using Domain.Interfaces;
using Domain.Models;
using Domain.Repository;
using Domain.Utils;

namespace Domain.Service
{
    public class AgencyService
    {
        private readonly IAgencyRepo _repo;
        private readonly IAgencyReader _reader;
        public AgencyService(IAgencyRepo repo, IAgencyReader reader) { _repo = repo; _reader = reader; }
        public IEnumerable<AgencyDTO> ReadAll()
        {
            return _reader.ReadAll();
        }
        public void Create(string agencyName, string phoneNumber)
        {
            var agency = new DAgency(agencyName, phoneNumber);
            _repo.Save(agency);
        }




        public void ExportToCsv(DAgency agency)
        {
            var csvExporter = new CSVExporter();
            agency.Accept(csvExporter);
        }
        public void ExportToNaturalLanguage(DAgency agency)
        {
            var txtExporter = new NaturalLanguageExporter();
            agency.Accept(txtExporter);
        }
    }
}
