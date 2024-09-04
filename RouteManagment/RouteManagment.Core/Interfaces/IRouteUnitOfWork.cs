using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface IRouteUnitOfWork : IDisposable
    {
        IRepository<Address> AddressRepository { get; }
        IRepository<Headquarter> HeadquarterRepository { get; }
        IRepository<Route> RouteRepository { get; }
        IRepository<Stop> StopRepository { get; }
        IRepository<RoutesStop> RoutesStopRepository { get; }
        IRepository<StreetType> StreetTypeRepository { get; }

        void SaveChanges();
        Task SaveChanguesAsync();
    }
}
