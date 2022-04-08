using System.Collections.Generic;
using Domain.Models;

namespace Domain.Interfaces
{
    public interface IAgencyReader
    {
        IEnumerable<AgencyDTO> ReadAll();
    }
}
