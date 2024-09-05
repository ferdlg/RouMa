using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;

namespace RouteManagment.Core.Services
{
    public class BaseRouteService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRouteUnitOfWork _unitOfWork;

        public BaseRouteService(IRouteUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;



        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.GetRepository<T>().GetAll();
        }

        public Task<T> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<T> Add(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(T entity)
        {
            _unitOfWork.GetRepository<T>().Update(entity);
            await _unitOfWork.SaveChanguesAsync();
            return (entity);
        }
        public Task<T> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
