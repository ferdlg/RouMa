using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface ITransportService
    {
        Task<IEnumerable<Transport>> GetTransports();
        Task<Transport> GetTransport(string? plate);
        Task PostTransport(Transport Transport);
        Task<bool> UpdateTransport(Transport transport);

        Task<bool> DeleteTransport(string? plate);
    }
}

