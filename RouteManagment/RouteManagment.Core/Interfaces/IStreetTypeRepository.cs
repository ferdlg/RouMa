using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IStreetTypeRepository
    {
        Task<IEnumerable<StreetType>> GetStreetTypes();
        Task<StreetType> GetStreetType(int id);
        Task PostStreetType(StreetType StreetType);
        Task<bool> UpdateStreetType(StreetType streetType);

        Task<bool> DeleteStreetType(int id);
    }
}
