using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class  TransportRepository : ITransportRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public TransportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all Transports
        public async Task<IEnumerable<Transport>> GetTransports()
        {
            var transports = await _appDbContext.Transports.ToListAsync();
            return transports;
        }

        //List Transport by id 
        public async Task<Transport> GetTransport(string? plate)
        {
            var transport = await _appDbContext.Transports
                .FirstOrDefaultAsync(Transport_x => Transport_x.Plate == plate);
            return transport;
        }

        // Create Transport

        public async Task PostTransport(Transport Transport)
        {
            _appDbContext.Transports.Add(Transport);
            await _appDbContext.SaveChangesAsync();

        }

        // Update transport by id 
        public async Task<bool> UpdateTransport(Transport transport)
        {
            var up_transport = await GetTransport(transport.Plate);
            up_transport.Capacity = transport.Capacity;
            up_transport.StateId = transport.StateId;
            up_transport.RouteId = transport.RouteId;
            up_transport.TransportTypeId = transport.TransportTypeId;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove transport by id
        public async Task<bool> DeleteTransport(string? plate)
        {
            var up_transport = await GetTransport(plate);
            _appDbContext.Transports.Remove(up_transport);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }

        IEnumerable<Transport> ITransportRepository.GetTransports()
        {
            throw new NotImplementedException();
        }
    }
}
