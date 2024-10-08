using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface IRouteUnitOfWork : IDisposable
    {
        IRepository<Route> RouteRepository { get; }
        IRepository<T> GetRepository<T>() where T : BaseEntity;


        void SaveChanges();
        Task SaveChanguesAsync();
    }
}
