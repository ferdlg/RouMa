using ManejoRutas.Core.Interfaces;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.Services
{
    public class RouteService : IRouteService 
    {
        private readonly IRepository<Route> _routeRepository;
        private readonly IRepository<Stop> _routeStopRepository;
        private readonly IRepository<RoutesStop> _stopRepository;
        public RouteService(IRouteRepository routeRepository, IRouteStopRepository routeStopRepository , IStopRepository stopRepository)
        {
            _routeRepository = routeRepository;
            _routeStopRepository = routeStopRepository;
            _stopRepository = stopRepository;
        }
    }
}
