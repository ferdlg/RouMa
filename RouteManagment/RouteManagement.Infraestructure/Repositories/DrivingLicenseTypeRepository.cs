using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class DrivingLicenseTypeRepository : IDrivingLicenseTypeRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public DrivingLicenseTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all DrivingLicenseTypes
        public async Task<IEnumerable<DrivingLicenseType>> GetDrivingLicenseTypes()
        {
            var DrivingLicenseTypes = await _appDbContext.DrivingLicenseTypes.ToListAsync();
            return DrivingLicenseTypes;
        }

        //List DrivingLicenseType by id 
        public async Task<DrivingLicenseType> GetDrivingLicenseType(int id)
        {
            var drivingLicenseType = await _appDbContext.DrivingLicenseTypes.FirstOrDefaultAsync(DrivingLicenseType_x => DrivingLicenseType_x.TypeLicenseId == id);
            return drivingLicenseType;
        }

        // Create DrivingLicenseType

        public async Task PostDrivingLicenseType(DrivingLicenseType DrivingLicenseType)
        {
            _appDbContext.DrivingLicenseTypes.Add(DrivingLicenseType);
            await _appDbContext.SaveChangesAsync();

        }

        // Update DrivingLicenseType by id 
        public async Task<bool> UpdateDrivingLicenseType(DrivingLicenseType DrivingLicenseType)
        {
            var up_DrivingLicenseType = await GetDrivingLicenseType(DrivingLicenseType.TypeLicenseId);
            up_DrivingLicenseType.Name = DrivingLicenseType.Name;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove DrivingLicenseType by id
        public async Task<bool> DeleteDrivingLicenseType(int id)
        {
            var up_DrivingLicenseType = await GetDrivingLicenseType(id);
            _appDbContext.DrivingLicenseTypes.Remove(up_DrivingLicenseType);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
