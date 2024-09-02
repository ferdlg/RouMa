using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface IunitOfWork : IDisposable
    {
        IRepository<Route> RouteRepository { get; }
        IRepository<Stop> StopRepository { get; }
        IRepository<RoutesStop> RoutesStopRepository { get; }
        IRepository<User> UserRepository { get; }
    }
}
