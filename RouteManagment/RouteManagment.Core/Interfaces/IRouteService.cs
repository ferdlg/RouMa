using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface IRouteService
    {
        IEnumerable<Route> GetRoutes();
        Task<Route> GetRouteById(int id);
        Task InsertRoute(Route route);
        Task<bool> Update(Route route);
        Task<bool> Delete(int id);
    }
}
