using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface ITransportService
    {
        IEnumerable<Transport> GetTransports();
        Task<Transport> GetTransport(string? plate);
        Task InsertTransport(Transport Transport);
        Task<bool> UpdateTransport(Transport transport);

        Task<bool> DeleteTransport(string? plate);
    }

    public interface IServiceT<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(int id);

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
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

            if (entity != null)
            {
                await _unitOfWork.GetRepository<T>().Delete(id);
            }
            return entity;
        }


    }
}

