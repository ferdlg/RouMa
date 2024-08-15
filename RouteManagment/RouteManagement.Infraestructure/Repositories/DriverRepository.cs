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

        // Update driver by id 
        public async Task<bool> UpdateDriver(Driver driver)
        {
            var up_driver = await GetDriver(driver.DriverId);
            up_driver.DocumentNumber = driver.DocumentNumber;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove driver by id
        public async Task<bool> DeleteDriver(int id)
        {
            var up_driver = await GetDriver(id);
            _appDbContext.Drivers.Remove(up_driver);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


    }
}
