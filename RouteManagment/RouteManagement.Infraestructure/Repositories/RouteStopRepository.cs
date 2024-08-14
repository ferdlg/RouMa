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

        //Update RouteStop 

        public async Task<RoutesStop> PutRoutesStop(int id)
        {
            var routeStop = _appDbContext.RoutesStops.FirstOrDefaultAsync(RouteStop_x => RouteStop_x.RouteStopId == id);
            _appDbContext.RoutesStops.Update(await routeStop);
            await _appDbContext.SaveChangesAsync();
            return await routeStop;
        }

        //Remove RouteStop by id 

        public async Task<RoutesStop> DeleteRoutesStop(int id)
        {
            var routeStop = await _appDbContext.RoutesStops.FirstOrDefaultAsync(RouteStop_x => RouteStop_x.RouteStopId == id);
            _appDbContext.RoutesStops.Remove(routeStop);
            await _appDbContext.SaveChangesAsync();
            return routeStop;
        }
    }
}
