using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface ITransportService
    {
        IEnumerable<Transport> GetTransports();
        Task<Transport> GetTransport(string plate);
        Task InsertTransport(Transport Transport);
        Task<bool> Update(Transport transport);
        Task<bool> Delete(string plate);
    }

    public interface IServiceT<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(int id);

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
   

    
}

