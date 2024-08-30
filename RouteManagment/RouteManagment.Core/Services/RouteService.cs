using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;

namespace RouteManagment.Core.Services
{
    public class RouteService : IRouteService 
    {
        private readonly IRepository<Route> _routeRepository;
        private readonly IRepository<Stop> _routeStopRepository;
        private readonly IRepository<RoutesStop> _stopRepository;
        private readonly IRepository<User> _userRepository;
        public RouteService(
                IRepository<Route> routeRepository,
                IRepository<Stop> routeStopRepository,
                IRepository<RoutesStop> stopRepository,
                IRepository<User> userRepository)
        {
            _routeRepository = routeRepository;
            _routeStopRepository = routeStopRepository;
            _stopRepository = stopRepository;
            _userRepository = userRepository;
        }

        public async Task<Route> GetRoute(int id)
        {
            return await _routeRepository.GetById(id);
        }

        public async Task<IEnumerable<Route>> GetRoutes()
        {
            return await _routeRepository.GetAll();
        }
        // Solo el admin puede crear rutas
        // Las rutas deben tener un minimo de paradas y un maximo

        public async Task InsertRoute(Route route)
        {

            //Validar que la ruta tenga un origen y un destino
            //si la ruta tiene un origen
        }
    }
}
