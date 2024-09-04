using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Data;

namespace RouteManagement.Infraestructure.Repositories
{
    public class RouteUnitOfWork : IRouteUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository<Route> _routeRepository;
        private readonly IRepository<Stop> _stopRepository;
        private readonly IRepository<RoutesStop> _routeStopRepository;
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Headquarter> _headquarterRepository;
        private readonly IRepository<StreetType> _streetTypeRepository;




        public RouteUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IRepository<Route> RouteRepository => _routeRepository ?? new BaseRepository<Route>(_appDbContext);

        public IRepository<Stop> StopRepository => _stopRepository ?? new BaseRepository<Stop>(_appDbContext);

        public IRepository<RoutesStop> RoutesStopRepository => _routeStopRepository ?? new BaseRepository<RoutesStop>(_appDbContext);

        public IRepository<Address> AddressRepository => throw new NotImplementedException();

        public IRepository<Headquarter> HeadquarterRepository => throw new NotImplementedException();

        public IRepository<StreetType> StreetTypeRepository => throw new NotImplementedException();

        public void Dispose() => _appDbContext?.Dispose();

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
