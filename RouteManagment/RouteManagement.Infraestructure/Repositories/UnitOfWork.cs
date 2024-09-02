using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagement.Infraestructure.Repositories
{
    public class UnitOfWork : IunitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly IRepository<Route> _routeRepository;
        private readonly IRepository<Stop> _stopRepository;
        private readonly IRepository<RoutesStop> _routeStopRepository ;
        private readonly IRepository<User> _userRepository;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IRepository<Route> RouteRepository => _routeRepository ?? new BaseRepository<Route>(_appDbContext);

        public IRepository<Stop> StopRepository => _stopRepository ?? new BaseRepository<Stop>(_appDbContext);

        public IRepository<RoutesStop> RoutesStopRepository => _routeStopRepository ?? new BaseRepository<RoutesStop>(_appDbContext);

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_appDbContext);

        public void Dispose()
        {
           if(_appDbContext != null)
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
