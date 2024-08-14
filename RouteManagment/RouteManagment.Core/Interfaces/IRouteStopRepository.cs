using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface IRouteStopRepository
    {
        Task<IEnumerable<RoutesStop>> GetRoutesStops();
        Task<RoutesStop> GetRoutesStop(int id);
        Task PostRoutesStop(RoutesStop RoutesStop);
        Task<RoutesStop> PutRoutesStop(int id);

        Task<RoutesStop> DeleteRoutesStop(int id);
    }
}
