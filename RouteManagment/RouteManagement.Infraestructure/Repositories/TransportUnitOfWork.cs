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
        private readonly ITransportRepository _transportRepository;
        private readonly IRepository<TransportState> _transportStateRepository;
        private readonly IRepository<TransportRequest> _transportRequestRepository;
        private readonly IRepository<TransportRequestState> _transportRequestStateRepository;
        private readonly IRepository<TransportType> _transportTypeRepository;

        public ITransportRepository TransportRepository => _transportRepository ?? new TransportRepository(_appDbContext);

        public IRepository<TransportRequest> TransportRequestRepository => _transportRequestRepository ?? new BaseRepository<TransportRequest>(_appDbContext);

        public IRepository<TransportState> TransporStateRepository => _transportStateRepository ?? new BaseRepository<TransportState>(_appDbContext);

        public IRepository<TransportRequestState> TransportRequestStateRepository => _transportRequestStateRepository ?? new BaseRepository<TransportRequestState>(_appDbContext);

        public IRepository<TransportType> TransportTypeRepository => _transportTypeRepository ?? new BaseRepository<TransportType>(_appDbContext);

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
