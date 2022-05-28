using Domain.Domain;
using Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UseCases.Create
{
    public class CreateRegularUser
    {
        private readonly IRegularUserRepo _regularUserRepo;

        public CreateRegularUser(IRegularUserRepo repo)
        {
            _regularUserRepo = repo;
        }

        public async Task<DRegularUser> Create(string regularUserId, string username, string phoneNumber,
            string firstName, string lastName, CancellationToken cancellationToken = default)
        {
            var dRegularUser = new DRegularUser(username, phoneNumber,
                firstName, lastName)
            { Id = regularUserId };
            return await _regularUserRepo.Add(dRegularUser, cancellationToken);
        }
    }
}
