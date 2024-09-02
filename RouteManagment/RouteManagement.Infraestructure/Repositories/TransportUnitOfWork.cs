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
        private readonly IRepository<TransportRequest> _transportRequestRepository;
        private readonly IRepository<Driver> _driverRepository;
        private readonly IRepository<Passenger> _passengerRepository;

        public ITransportRepository TransportRepository => _transportRepository ?? new TransportRepository(_appDbContext);

        public IRepository<TransportRequest> TransportRequestRepository => _transportRequestRepository ?? new BaseRepository<TransportRequest>(_appDbContext);

        public IRepository<Driver> DriverRepository => _driverRepository ?? new BaseRepository<Driver>(_appDbContext);

        public IRepository<Passenger> PassengerRepository => _passengerRepository ?? new BaseRepository<Passenger>(_appDbContext);
        public void Dispose()
        {
            if (_appDbContext != null)
            {
                _appDbContext.Dispose();
            }
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public async Task SaveChanguesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
