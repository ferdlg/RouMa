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

        // Update transportStatus by id 
        public async Task<bool> UpdatetransportStatus(TransportStatus transportStatus)
        {
            var up_transportStatus = await GetTransportStatus(transportStatus.StatusId);
            up_transportStatus.Status = transportStatus.Status;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove transportStatus by id
        public async Task<bool> DeleteTransportStatus(int id)
        {
            var up_transportStatus = await GetTransportStatus(id);
            _appDbContext.TransportStatuses.Remove(up_transportStatus);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
