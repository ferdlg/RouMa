using ManejoRutas.Core.Interfaces;
using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface ITransportUnitOfWork : IDisposable
    {
        ITransportRepository TransportRepository { get; }
        IRepository<T> GetRepository<T>() where T : BaseEntity;


        void SaveChange();
        Task SaveChangesAsync();

    }
}
