using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportRepository
    {
        Task<IEnumerable<Transport>> GetTransports();
        Task<Transport> GetTransport(int id);
        Task PostTransport(Transport Transport);
        Task<bool> UpdateTransport(Transport transport);

        Task<bool> DeleteTransport(int id);
    }
}
