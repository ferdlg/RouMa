using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportRequestRepository
    {
        Task<IEnumerable<TransportRequest>> GetTransportRequests();
        Task<TransportRequest> GetTransportRequest(int id);
        Task PostTransportRequest(TransportRequest TransportRequest);
        Task<TransportRequest> PutTransportRequest(int id);

        Task<TransportRequest> DeleteTransportRequest(int id);
    }
}
