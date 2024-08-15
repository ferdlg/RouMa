using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetDrivers();
        Task<Driver> GetDriver(int id);
        Task PostDriver(Driver Driver);
        Task<bool> UpdateDriver(Driver driver);

        Task<bool> DeleteDriver(int id);
    }
}
