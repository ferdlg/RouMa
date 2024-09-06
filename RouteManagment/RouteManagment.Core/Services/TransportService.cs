using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;

namespace RouteManagment.Core.Services
{
    public class TransportService : ITransportService
    {
        private readonly ITransportUnitOfWork _unitOfwork;
        public TransportService(ITransportUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        IEnumerable<Transport> ITransportService.GetTransports()
        {
            return _unitOfwork.TransportRepository.GetTransports();
        }
        public async  Task<Transport> GetTransport(string? plate)
        {
            return await _unitOfwork.TransportRepository.GetTransport(plate);
        }
        public async Task InsertTransport(Transport Transport)
        {
            await _unitOfwork.TransportRepository.PostTransport(Transport);
        }

        public async Task<bool> UpdateTransport(Transport transport)
        {
            await _unitOfwork.TransportRepository.UpdateTransport(transport);
            await _unitOfwork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteTransport(string? plate)
        {
            await _unitOfwork.TransportRepository.DeleteTransport(plate);
            return true;
        }

    }
}
