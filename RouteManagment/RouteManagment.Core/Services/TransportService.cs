using RouteManagment.Core.Entities;
using RouteManagment.Core.Exceptions;
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

        private async Task ValidationTransportExist(string plate)
        {
            var transport = await _unitOfwork.TransportRepository.GetTransport(plate);
            if (transport == null)
            {
                throw new BussinesExceptions(ErrorCode.NotFound, message: $"Transport with plate{plate} not found.");
            }
        }
        private async Task ValidationTransportCapacity(string plate, int numberPassengers)
        {
            await ValidationTransportExist(plate);
            var transport = await _unitOfwork.TransportRepository.GetTransport(plate);
            var capacity = transport.Capacity;
            var minCapacity = (capacity / 2);


            if (numberPassengers > capacity)
            {
                throw new BussinesExceptions(ErrorCode.Forbidden, message: "The number of passengers exceeds the capacity.");
            }
            if (numberPassengers < minCapacity)
            {
                throw new BussinesExceptions(ErrorCode.Forbidden, message: "The number of passengers does not meet the minimum capacity");
            }
        }

        public IEnumerable<Transport> GetTransports()
        {
            return _unitOfwork.TransportRepository.GetTransports();
        }

        public async Task<Transport> GetTransport(string? plate)
        {
            return await _unitOfwork.TransportRepository.GetTransport(plate);
        }

        public async Task InsertTransport(Transport Transport)
        {
            await _unitOfwork.TransportRepository.AddTransport(Transport);
            await _unitOfwork.SaveChangesAsync();
        }

        public async Task<bool> Update(Transport transport)
        {
            _unitOfwork.TransportRepository.UpdateTransport(transport);
            await _unitOfwork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string plate)
        {
            await _unitOfwork.TransportRepository.DeleteTransport(plate);
            return true;
        }
    }


    public class BaseServiceT<T> : IServiceT<T> where T : BaseEntity
    {
        private readonly ITransportUnitOfWork _unitOfWork;
        public BaseServiceT(ITransportUnitOfWork iunitOfWork)
        {
            _unitOfWork = iunitOfWork;

        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.GetRepository<T>().GetAll();

        }
        public async Task<T> GetById(int id)
        {
            return await _unitOfWork.GetRepository<T>().GetById(id);

        }

        public async Task<T> Add(T entity)
        {
            await _unitOfWork.GetRepository<T>().Add(entity);
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _unitOfWork.GetRepository<T>().Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var entity = await _unitOfWork.GetRepository<T>().GetById(id);
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }


    }
}



