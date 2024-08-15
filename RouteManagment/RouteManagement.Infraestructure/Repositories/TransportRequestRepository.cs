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
    public class TransportRequestRepository : ITransportRequestRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public TransportRequestRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all TransportRequests
        public async Task<IEnumerable<TransportRequest>> GetTransportRequests()
        {
            var transportRequests = await _appDbContext.TransportRequests.ToListAsync();
            return transportRequests;
        }

        //List TransportRequest by id 
        public async Task<TransportRequest> GetTransportRequest(int id)
        {
            var transportRequest = await _appDbContext.TransportRequests.FirstOrDefaultAsync(TransportRequest_x => TransportRequest_x.RequestId== id);
            return transportRequest;
        }

        // Create TransportRequest

        public async Task PostTransportRequest(TransportRequest transportRequest)
        {
            _appDbContext.TransportRequests.Add(transportRequest);
            await _appDbContext.SaveChangesAsync();

        }

        // Update transportRequest by id 
        public async Task<bool> UpdateTransportRequest(TransportRequest transportRequest)
        {
            var up_transportRequest = await GetTransportRequest(transportRequest.RequestId);
            up_transportRequest.Date = transportRequest.Date;
            up_transportRequest.Description = transportRequest.Description;
            up_transportRequest.TransportType = transportRequest.TransportType;
            up_transportRequest.CompanyId = transportRequest.CompanyId;
            up_transportRequest.AdministratorId = transportRequest.AdministratorId;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove transportRequest by id
        public async Task<bool> DeleteTransportRequest(int id)
        {
            var up_transportRequest = await GetTransportRequest(id);
            _appDbContext.TransportRequests.Remove(up_transportRequest);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
