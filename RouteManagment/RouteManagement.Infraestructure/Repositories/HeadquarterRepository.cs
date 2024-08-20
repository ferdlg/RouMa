using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class HeadquarterRepository : IHeadquarterRespository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public HeadquarterRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all Headquarters
        public async Task<IEnumerable<Headquarter>> GetHeadquarters()
        {
            var Headquarters = await _appDbContext.Headquarters.ToListAsync();
            return Headquarters;
        }

        //List Headquarter by id 
        public async Task<Headquarter> GetHeadquarter(int id)
        {
            var Headquarter = await _appDbContext.Headquarters.FirstOrDefaultAsync(Headquarter_x => Headquarter_x.HeadQuarterId == id);
            return Headquarter;
        }

        // Create Headquarter

        public async Task PostHeadquarter(Headquarter Headquarter)
        {
            _appDbContext.Headquarters.Add(Headquarter);
            await _appDbContext.SaveChangesAsync();

        }

        // Update Headquarter by id 
        public async Task<bool> UpdateHeadquarter(Headquarter Headquarter)
        {
            var up_Headquarter = await GetHeadquarter(Headquarter.HeadQuarterId);
            up_Headquarter.AddressId = Headquarter.AddressId;
            up_Headquarter.CompanyId = Headquarter.CompanyId;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove Headquarter by id
        public async Task<bool> DeleteHeadquarter(int id)
        {
            var up_Headquarter = await GetHeadquarter(id);
            _appDbContext.Headquarters.Remove(up_Headquarter);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }

    }
}
