using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Data;

namespace RouteManagement.Infraestructure.Repositories
{
    public class RouteUnitOfWork : IRouteUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly Dictionary<Type, object> _respositories;
        private readonly IRepository<Route> _routeRepository;


        public RouteUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

            _respositories = new Dictionary<Type, object>
            {
                { typeof(Route), new BaseRepository<Route>(appDbContext) },
                { typeof(Stop), new BaseRepository<Stop>(appDbContext) },
                { typeof(RoutesStop), new BaseRepository<RoutesStop>(appDbContext) },
                { typeof(Address), new BaseRepository<Address>(appDbContext) },
                { typeof(Headquarter), new BaseRepository<Headquarter>(appDbContext) },
                { typeof(StreetType), new BaseRepository<StreetType>(appDbContext) }
            };
        }
        public IRepository<Route> RouteRepository => _routeRepository ?? new BaseRepository<Route>(_appDbContext);
        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_respositories.TryGetValue(typeof(T), out var repository))
            {
                return (IRepository<T>)repository;
            }

            throw new InvalidOperationException($"Repository not found for type {typeof(T).Name}");
        }



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
