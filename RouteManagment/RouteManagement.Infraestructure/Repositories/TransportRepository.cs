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
        public async Task<Transport> GetTransport(int id)
        {
            var transport = await _appDbContext.Transports.FirstOrDefaultAsync(Transport_x => Transport_x.Plate == id);
            return transport;
        }

        // Create Transport

        public async Task PostTransport(Transport Transport)
        {
            _appDbContext.Transports.Add(Transport);
            await _appDbContext.SaveChangesAsync();

        }

        //Update Transport 

        public async Task<Transport> PutTransport(int id)
        {
            var transport = _appDbContext.Transports.FirstOrDefaultAsync(Transport_x => Transport_x.Plate == id);
            _appDbContext.Transports.Update(await transport);
            await _appDbContext.SaveChangesAsync();
            return await transport;
        }

        //Remove Transport by id 

        public async Task<Transport> DeleteTransport(int id)
        {
            var transport = await _appDbContext.Transports.FirstOrDefaultAsync(Transport_x => Transport_x.Plate == id);
            _appDbContext.Transports.Remove(transport);
            await _appDbContext.SaveChangesAsync();
            return transport;
        }
    }
}
