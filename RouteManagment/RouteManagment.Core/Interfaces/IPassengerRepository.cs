using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> GetPassengers();
        Task<Passenger> GetPassenger(int id);
        Task PostPassenger(Passenger Passenger);
        Task<bool> UpdatePassenger(Passenger passenger);

        Task<bool> DeletePassenger(int id);
    }
}
