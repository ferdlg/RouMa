using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class  RouteRepository : IRouteRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public RouteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all Routes
        public async Task<IEnumerable<Route>> GetRoutes()
        {
            var routes = await _appDbContext.Routes.ToListAsync();
            return routes;
        }

        //List Route by id 
        public async Task<Route> GetRoute(int id)
        {
            var route = await _appDbContext.Routes.FirstOrDefaultAsync(Route_x => Route_x.RouteId == id);
            return route;
        }

        // Create Route

        public async Task PostRoute(Route route)
        {
            _appDbContext.Routes.Add(route);
            await _appDbContext.SaveChangesAsync();

        }

        // Update route by id 
        public async Task<bool> UpdateRoute(Route route)
        {
            var up_route = await GetRoute(route.RouteId);
            up_route.AddressOriginId = route.AddressOriginId;
            up_route.AddressHeadQuarterId = route.AddressHeadQuarterId;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove route by id
        public async Task<bool> DeleteRoute(int id)
        {
            var up_route = await GetRoute(id);
            _appDbContext.Routes.Remove(up_route);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
