using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Data;

namespace RouteManagement.Infraestructure.Repositories
{
    public class TransportUnitOfWork : ITransportUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly Dictionary<Type, object> _repositories;
        private readonly ITransportRepository _transportRepository;

        public TransportUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _repositories = new Dictionary<Type, object>
            {
                { typeof(TransportState), new BaseRepository<TransportState>(appDbContext) },
                { typeof(TransportRequest), new BaseRepository<TransportRequest>(appDbContext) },
                { typeof(TransportRequestState), new BaseRepository<TransportRequestState>(appDbContext) },
                { typeof(TransportType), new BaseRepository<TransportType>(appDbContext) }
            };
        }

        public ITransportRepository TransportRepository => _transportRepository ?? new TransportRepository(_appDbContext);

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_repositories.TryGetValue(typeof(T), out var repository))
            {
                return (IRepository<T>)repository;
            }

            throw new InvalidOperationException($"Repository not found for type {typeof(T).Name}");
        }

        public void Dispose() => _appDbContext?.Dispose();

        public void SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

    }
}
