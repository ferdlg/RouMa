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

        //Update TransportRequest 

        public async Task<TransportRequest> PutTransportRequest(int id)
        {
            var transportRequest = _appDbContext.TransportRequests.FirstOrDefaultAsync(TransportRequest_x => TransportRequest_x.RequestId== id);
            _appDbContext.TransportRequests.Update(await transportRequest);
            await _appDbContext.SaveChangesAsync();
            return await transportRequest;
        }

        //Remove TransportRequest by id 

        public async Task<TransportRequest> DeleteTransportRequest(int id)
        {
            var transportRequest = await _appDbContext.TransportRequests.FirstOrDefaultAsync(TransportRequest_x => TransportRequest_x.RequestId== id);
            _appDbContext.TransportRequests.Remove(transportRequest);
            await _appDbContext.SaveChangesAsync();
            return transportRequest;
        }
    }
}
