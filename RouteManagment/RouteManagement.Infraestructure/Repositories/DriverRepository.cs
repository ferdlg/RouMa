using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class  DriverRepository : IDriverRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public DriverRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all Drivers
        public async Task<IEnumerable<Driver>> GetDrivers()
        {
            var Drivers = await _appDbContext.Drivers.ToListAsync();
            return Drivers;
        }

        //List Driver by id 
        public async Task<Driver> GetDriver(int id)
        {
            var Driver = await _appDbContext.Drivers.FirstOrDefaultAsync(Driver_x => Driver_x.DriverId == id);
            return Driver;
        }

        // Create Driver

        public async Task PostDriver(Driver Driver)
        {
            _appDbContext.Drivers.Add(Driver);
            await _appDbContext.SaveChangesAsync();

        }

        //Update Driver 

        public async Task<Driver> PutDriver(int id)
        {
            var Driver = _appDbContext.Drivers.FirstOrDefaultAsync(Driver_x => Driver_x.DriverId == id);
            _appDbContext.Drivers.Update(await Driver);
            await _appDbContext.SaveChangesAsync();
            return await Driver;
        }

        //Remove Driver by id 

        public async Task<Driver> DeleteDriver(int id)
        {
            var Driver = await _appDbContext.Drivers.FirstOrDefaultAsync(Driver_x => Driver_x.DriverId == id);
            _appDbContext.Drivers.Remove(Driver);
            await _appDbContext.SaveChangesAsync();
            return Driver;
        }
    }
}
