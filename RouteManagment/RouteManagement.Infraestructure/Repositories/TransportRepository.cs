using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;
using System.Security.Cryptography.Xml;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class  TransportRepository : ITransportRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;
        private readonly DbSet<Transport> _transports;

        public TransportRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _transports = appDbContext.Set<Transport>();
        }
        public IEnumerable<Transport> GetTransports()
        {
            return _transports.AsEnumerable();
        }

        public async Task<Transport> GetTransport(string? plate)
        {
            return await _transports.FindAsync(plate);
        }

        public async Task AddTransport(Transport Transport)
        {
            await _transports.AddAsync(Transport);
        }



        public void UpdateTransport(Transport transport)
        {
            _transports.Update(transport);
        }
        public async Task DeleteTransport(string? plate)
        {
            var rmTransport = await GetTransport(plate);
            _transports.Remove(rmTransport);
        }
    }
}
