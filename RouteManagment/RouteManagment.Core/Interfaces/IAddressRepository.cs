using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses();

        Task<Address> GetAddress(int id);

        Task PostAddress(Address address);
        Task<Address> PutAddress(int id);

        Task<Address> DeleteAddress(int id);
    }
}
