using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportRepository
    {
        IEnumerable<Transport> GetTransports();
        Task<Transport> GetTransport(string? plate);
        Task AddTransport(Transport Transport);
        void UpdateTransport(Transport transport);

        Task DeleteTransport(string? plate);
    }
}
