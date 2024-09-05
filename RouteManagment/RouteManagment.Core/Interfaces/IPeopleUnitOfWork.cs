using RouteManagment.Core.Entities;

namespace RouteManagment.Core.Interfaces
{
    public interface IPeopleUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<People> PeopleRepository { get; }
        IRepository<T> GetRepository<T>() where T : BaseEntity;

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
