using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportRequestRepository
    {
        Task<IEnumerable<TransportRequest>> GetTransportRequests();
        Task<TransportRequest> GetTransportRequest(int id);
        Task PostTransportRequest(TransportRequest TransportRequest);
        Task<bool> UpdateTransportRequest(TransportRequest transportRequest);

        Task<bool> DeleteTransportRequest(int id);
    }
}
