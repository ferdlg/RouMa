using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        Task<User> GetUserById(int id);
        Task InsertUser(User user);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
    }
    public interface IPeopleService
    {
        IEnumerable<People> GetPeople();
        Task<People> GetPeopleById(int id);
        Task InsertPeople(People people);
        Task<bool> Update(People people);
        Task<bool> Delete(int id);
    }

    public interface IServiceP<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();

        Task<T> GetById(int id);

        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);

    }


}
