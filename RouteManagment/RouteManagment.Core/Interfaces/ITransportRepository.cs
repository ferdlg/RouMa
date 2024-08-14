using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportRepository
    {
        Task<IEnumerable<Transport>> GetTransports();
        Task<Transport> GetTransport(int id);
        Task PostTransport(Transport Transport);
        Task<Transport> PutTransport(int id);

        Task<Transport> DeleteTransport(int id);
    }
}
