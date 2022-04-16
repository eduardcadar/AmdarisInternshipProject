using Domain.Domain;
using Domain.Repository;

namespace Application.UseCases.Create
{
    public class CreateAgency
    {
        private readonly IAgencyRepo _repo;

        public CreateAgency(IAgencyRepo repo)
        {
            _repo = repo;
        }

        public void Create(string agencyName, string phoneNumber)
        {
            var dAgency = new DAgency(agencyName, phoneNumber);
            _repo.Add(dAgency);
        }
    }
}
