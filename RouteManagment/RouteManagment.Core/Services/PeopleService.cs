using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;

namespace RouteManagment.Core.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleUnitOfWork _unitOfWork;

        public PeopleService(IPeopleUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<People> GetPeople()
        {
            return _unitOfWork.PeopleRepository.GetAll();
        }

        public async Task<People> GetPeopleById(int id)
        {
            return await _unitOfWork.PeopleRepository.GetById(id);
        }

        public async Task InsertPeople(People people)
        {
            await _unitOfWork.PeopleRepository.Add(people);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Update(People people)
        {
            _unitOfWork.PeopleRepository.Update(people);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.PeopleRepository.Delete(id);
            return true;
        }
    }

    public class UserService : IUserService
    {
        private readonly IPeopleUnitOfWork _unitOfWork;

        public UserService(IPeopleUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<User> GetUsers()
        {
            return _unitOfWork.UserRepository.GetAll();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.UserRepository.GetById(id);
        }


        public async Task InsertUser(User user)
        {
            await _unitOfWork.UserRepository.Add(user);
        }

        public async Task<bool> Update(User user)
        {
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            return true;
        }
    }

    public class BaseServiceP <T> : IServiceP<T> where T : BaseEntity
    {
        private readonly IPeopleUnitOfWork _unitOfWork;

        public BaseServiceP(IPeopleUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
