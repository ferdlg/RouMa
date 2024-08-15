using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class RouteStopRepository : IRouteStopRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public RouteStopRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all RouteStops
        public async Task<IEnumerable<RoutesStop>> GetRoutesStops()
        {
            var routeStops = await _appDbContext.RoutesStops.ToListAsync();
            return routeStops;
        }

        //List RouteStop by id 
        public async Task<RoutesStop> GetRoutesStop(int id)
        {
            var routeStop = await _appDbContext.RoutesStops.FirstOrDefaultAsync(RouteStop_x => RouteStop_x.RouteStopId == id);
            return routeStop;
        }

        // Create RouteStop

        public async Task PostRoutesStop(RoutesStop RouteStop)
        {
            _appDbContext.RoutesStops.Add(RouteStop);
            await _appDbContext.SaveChangesAsync();

        }

        // Update routeStop by id 
        public async Task<bool> UpdateRouteStop(RoutesStop routeStop)
        {
            var up_routeStop = await GetRoutesStop(routeStop.RouteStopId);
            up_routeStop.RouteId = routeStop.RouteId;
            up_routeStop.StopId = routeStop.StopId;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove routeStop by id
        public async Task<bool> DeleteRouteStop(int id)
        {
            var up_routeStop = await GetRoutesStop(id);
            _appDbContext.RoutesStops.Remove(up_routeStop);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
