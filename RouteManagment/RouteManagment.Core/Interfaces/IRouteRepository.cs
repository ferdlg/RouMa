using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IRouteRepository
    {
        Task<IEnumerable<Route>> GetRoutes();
        Task<Route> GetRoute(int id);
        Task PostRoute(Route Route);
        Task<Route> PutRoute(int id);

        Task<Route> DeleteRoute(int id);
    }
}
