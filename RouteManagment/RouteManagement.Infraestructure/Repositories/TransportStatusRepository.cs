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
    public class TransportStatusRepository : ITransportStatusRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public TransportStatusRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all TransportStatus
        public async Task<IEnumerable<TransportStatus>> GetTransportStatuss()
        {
            var transportStatus = await _appDbContext.TransportStatuses.ToListAsync();
            return transportStatus;
        }

        //List TransportStatus by id 
        public async Task<TransportStatus> GetTransportStatus(int id)
        {
            var transportStatus = await _appDbContext.TransportStatuses.FirstOrDefaultAsync(TransportStatus_x => TransportStatus_x.StatusId== id);
            return transportStatus;
        }

        // Create TransportStatus

        public async Task PostTransportStatus(TransportStatus TransportStatus)
        {
            _appDbContext.TransportStatuses.Add(TransportStatus);
            await _appDbContext.SaveChangesAsync();

        }

        //Update TransportStatus 

        public async Task<TransportStatus> PutTransportStatus(int id)
        {
            var transportStatus = _appDbContext.TransportStatuses.FirstOrDefaultAsync(TransportStatus_x => TransportStatus_x.StatusId== id);
            _appDbContext.TransportStatuses.Update(await transportStatus);
            await _appDbContext.SaveChangesAsync();
            return await transportStatus;
        }

        //Remove TransportStatus by id 

        public async Task<TransportStatus> DeleteTransportStatus(int id)
        {
            var transportStatus = await _appDbContext.TransportStatuses.FirstOrDefaultAsync(TransportStatus_x => TransportStatus_x.StatusId== id);
            _appDbContext.TransportStatuses.Remove(transportStatus);
            await _appDbContext.SaveChangesAsync();
            return transportStatus;
        }
    }
}
