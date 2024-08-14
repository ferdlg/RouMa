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
    public class StopRepository : IStopRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public StopRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all stops
        public async Task<IEnumerable<Stop>> GetStops()
        {
            var stops = await _appDbContext.Stops.ToListAsync();
            return stops;
        }

        //List stop by id 
        public async Task<Stop> GetStop(int id)
        {
            var stop = await _appDbContext.Stops.FirstOrDefaultAsync(stop_x => stop_x.StopId == id);
            return stop;
        }

        // Create stop

        public async Task PostStop(Stop stop)
        {
            _appDbContext.Stops.Add(stop);
            await _appDbContext.SaveChangesAsync();

        }

        //Update stop 

        public async Task<Stop> PutStop(int id)
        {
            var stop = _appDbContext.Stops.FirstOrDefaultAsync(stop_x => stop_x.StopId == id);
            _appDbContext.Stops.Update(await stop);
            await _appDbContext.SaveChangesAsync();
            return await stop;
        }

        //Remove stop by id 

        public async Task<Stop> DeleteStop(int id)
        {
            var stop = await _appDbContext.Stops.FirstOrDefaultAsync(stop_x => stop_x.StopId == id);
            _appDbContext.Stops.Remove(stop);
            await _appDbContext.SaveChangesAsync();
            return stop;
        }
    }
}
