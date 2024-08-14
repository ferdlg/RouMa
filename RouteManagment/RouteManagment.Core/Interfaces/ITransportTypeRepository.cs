using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportTypeRepository
    {
        Task<IEnumerable<TransportType>> GetTransportTypes();
        Task<TransportType> GetTransportType(int id);
        Task PostTransportType(TransportType TransportType);
        Task<TransportType> PutTransportType(int id);

        Task<TransportType> DeleteTransportType(int id);
    }
}
