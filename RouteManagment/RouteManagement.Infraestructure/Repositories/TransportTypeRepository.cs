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
    public class TransportTypeRepository : ITransportTypeRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public TransportTypeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all TransportTypes
        public async Task<IEnumerable<TransportType>> GetTransportTypes()
        {
            var TransportTypes = await _appDbContext.TransportTypes.ToListAsync();
            return TransportTypes;
        }

        //List TransportType by id 
        public async Task<TransportType> GetTransportType(int id)
        {
            var TransportType = await _appDbContext.TransportTypes.FirstOrDefaultAsync(TransportType_x => TransportType_x.TransportTypeId == id);
            return TransportType;
        }

        // Create TransportType

        public async Task PostTransportType(TransportType TransportType)
        {
            _appDbContext.TransportTypes.Add(TransportType);
            await _appDbContext.SaveChangesAsync();

        }

        // Update transportType by id 
        public async Task<bool> UpdateTransportType(TransportType transportType)
        {
            var up_transportType = await GetTransportType(transportType.TransportTypeId);
            up_transportType.Name = transportType.Name;
            up_transportType.Description = transportType.Description;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove transportType by id
        public async Task<bool> DeleteTransportType(int id)
        {
            var up_transportType = await GetTransportType(id);
            _appDbContext.TransportTypes.Remove(up_transportType);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
