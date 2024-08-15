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
    public class StreetTypeRepository : IStreetTypeRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public StreetTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all StreetTypes
        public async Task<IEnumerable<StreetType>> GetStreetTypes()
        {
            var streetTypes = await _appDbContext.StreetTypes.ToListAsync();
            return streetTypes;
        }

        //List StreetType by id 
        public async Task<StreetType> GetStreetType(int id)
        {
            var streetType = await _appDbContext.StreetTypes.FirstOrDefaultAsync(StreetType_x => StreetType_x.StreetTypeId == id);
            return streetType;
        }

        // Create StreetType

        public async Task PostStreetType(StreetType StreetType)
        {
            _appDbContext.StreetTypes.Add(StreetType);
            await _appDbContext.SaveChangesAsync();

        }
        // Update streetType by id 
        public async Task<bool> UpdateStreetType(StreetType streetType)
        {
            var up_streetType = await GetStreetType(streetType.StreetTypeId);
            up_streetType.Name = streetType.Name;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove streetType by id
        public async Task<bool> DeleteStreetType(int id)
        {
            var up_streetType = await GetStreetType(id);
            _appDbContext.StreetTypes.Remove(up_streetType);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
