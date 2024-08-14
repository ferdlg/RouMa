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

        //Update TransportType 

        public async Task<TransportType> PutTransportType(int id)
        {
            var TransportType = _appDbContext.TransportTypes.FirstOrDefaultAsync(TransportType_x => TransportType_x.TransportTypeId == id);
            _appDbContext.TransportTypes.Update(await TransportType);
            await _appDbContext.SaveChangesAsync();
            return await TransportType;
        }

        //Remove TransportType by id 

        public async Task<TransportType> DeleteTransportType(int id)
        {
            var TransportType = await _appDbContext.TransportTypes.FirstOrDefaultAsync(TransportType_x => TransportType_x.TransportTypeId == id);
            _appDbContext.TransportTypes.Remove(TransportType);
            await _appDbContext.SaveChangesAsync();
            return TransportType;
        }
    }
}
