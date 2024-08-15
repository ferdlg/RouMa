using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportTypeRepository
    {
        Task<IEnumerable<TransportType>> GetTransportTypes();
        Task<TransportType> GetTransportType(int id);
        Task PostTransportType(TransportType TransportType);
        Task<bool> UpdateTransportType(TransportType transportType);

        Task<bool> DeleteTransportType(int id);
    }
}
