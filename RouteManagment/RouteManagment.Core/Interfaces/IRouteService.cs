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

    public interface IAddressService : IService<Address>
    {
    }
    public interface IStopService : IService<Stop>
    {
    }
    public interface IRouteStopService : IService<RoutesStop>
    {
    }
    public interface IHeadquarterService : IService <Headquarter>
    {
    }
    public interface IStreetTypeService : IService<StreetType> 
    {
    }
}
