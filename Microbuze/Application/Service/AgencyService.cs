using Application.Domain;
using Application.Repository;
using Application.Utils;

namespace Application.Service
{
    public class AgencyService
    {
        private readonly IAgencyRepo _repo;
        public AgencyService(IAgencyRepo repo) { _repo = repo; }
        public void ExportToCsv(Agency agency)
        {
            var csvExporter = new CSVExporter();
            agency.Accept(csvExporter);
        }
        public void ExportToNaturalLanguage(Agency agency)
        {
            var txtExporter = new NaturalLanguageExporter();
            agency.Accept(txtExporter);
        }
    }
}
