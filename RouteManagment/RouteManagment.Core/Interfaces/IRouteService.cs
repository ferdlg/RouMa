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

    public interface IServiceR<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(int id);

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}
