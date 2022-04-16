using Application.Models;

namespace Application.Interfaces
{
    public interface IAgencyReader
    {
        AgencyDTO GetById(int id);
    }
}
