using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface ITransportService
    {
        IEnumerable<Transport> GetTransports();
        Task<Transport> GetTransport(string? plate);
        Task PostTransport(Transport Transport);
        Task<bool> UpdateTransport(Transport transport);

        Task<bool> DeleteTransport(string? plate);
    }
    public interface ITransportState : IService<TransportState>
    {
    }
    public interface ITransportRequest : IService<TransportRequest>
    {
    }
    public interface ITransportRequestState : IService<TransportRequestState>
    {
    }
    public interface ITransportType : IService<TransportType>
    {
    }
}

