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
        public async Task<bool> UpdateAddress(Address address)
        {
            var up_address = await GetAddress(address.AddressId);
            up_address.StreetNumber = address.StreetNumber;
            up_address.Quadrant = address.Quadrant;
            up_address.Plate = address.Plate;
            up_address.Prefix = address.Prefix;
            up_address.StreetTypeId = address.StreetTypeId;

            int rows =  await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove address by id
        public async Task<bool> DeleteAddress(int id)
        {
            var up_address = await GetAddress(id);
            _appDbContext.Addresses.Remove(up_address);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
