using System.Collections.Generic;
using Application.Domain;

namespace Application.Repository
{
    public interface IAgencyRepo
    {
        public void Save(Agency agency);
        public ICollection<Agency> GetAll();
    }
}
