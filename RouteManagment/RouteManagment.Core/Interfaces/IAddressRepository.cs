using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses();

        Task<Address> GetAddress(int id);

        Task PostAddress(Address address);
        Task<bool> UpdateAddress(Address address);

        Task<bool> DeleteAddress(int id);
    }
}
