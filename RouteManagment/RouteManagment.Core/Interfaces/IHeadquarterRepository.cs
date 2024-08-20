using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IHeadquarterRespository
    {
        Task<IEnumerable<Headquarter>> GetHeadquarters();
        Task<Headquarter> GetHeadquarter(int id);
        Task PostHeadquarter(Headquarter Headquarter);
        Task<bool> UpdateHeadquarter(Headquarter Headquarter);
        Task<bool> DeleteHeadquarter(int id);
    }
}
