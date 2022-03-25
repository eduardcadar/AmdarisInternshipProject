using System.Collections.Generic;
using Domain.Domain;
using Domain.Repository;

namespace Service
{
    public class AgencyService
    {
        private IAgencyRepo repo;
        public AgencyService(IAgencyRepo repo) { this.repo = repo; }
        public void Save(string agencyName) => this.repo.Save(new Agency(agencyName));
        public Agency GetById(int id) => this.repo.GetById(id);
        public ICollection<Agency> GetAll() => this.repo.GetAll();
    }
}
