using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        // Logic for CRUD methods
        private readonly AppDbContext _appDbContext;

        public AddressRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        //List all addresses

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            var addresses = await _appDbContext.Addresses.ToListAsync();
            return addresses;
        }

        //List addresses by id

        public async Task<Address> GetAddress(int id)
        {
            var address = await _appDbContext.Addresses.FirstOrDefaultAsync(address_x => address_x.AddressId == id);
            return address;
        }

        // Create addresses
        public async Task PostAddress(Address address)
        {
            _appDbContext.Addresses.Add(address);
            await _appDbContext.SaveChangesAsync();
        }
        // Update address by id 

        public async Task<Address> PutAddress(int id)
        {
            var address = await _appDbContext.Addresses.FirstOrDefaultAsync(address_x => address_x.AddressId == id);
            _appDbContext.Addresses.Update(address);
            await _appDbContext.SaveChangesAsync();
            return address;

        }

        // Remove address by id
        public async Task<Address> DeleteAddress(int id)
        {
            var address = await _appDbContext.Addresses.FirstOrDefaultAsync(address_x => address_x.AddressId == id);
            _appDbContext.Addresses.Remove(address);
            await _appDbContext.SaveChangesAsync();
            return address;

        }
    }
}
