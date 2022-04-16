using Domain.Domain;
using Domain.Repository;

namespace Application.UseCases.Create
{
    public class CreateAgencyUser
    {
        private readonly IAgencyUserRepo _repo;

        public CreateAgencyUser(IAgencyUserRepo repo)
        {
            _repo = repo;
        }

        public void Create(string username, string password, string phoneNumber, DAgency dAgency)
        {
            var dAgencyUser = new DAgencyUser(username, password, phoneNumber, dAgency);
            _repo.Add(dAgencyUser);
        }
    }
}
