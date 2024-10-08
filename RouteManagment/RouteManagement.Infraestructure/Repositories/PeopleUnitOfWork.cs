using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Data;

namespace RouteManagement.Infraestructure.Repositories
{
    public class PeopleUnitOfWork : IPeopleUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        private readonly Dictionary<Type, object> _repositories;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<People> _peopleRepository;

        public PeopleUnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _repositories = new Dictionary<Type, object>
            {
                { typeof(Administrator), new BaseRepository<Administrator>(appDbContext) },
                { typeof(CompanyAdministrator), new BaseRepository<CompanyAdministrator>(appDbContext) },
                { typeof(Company), new BaseRepository<Company>(appDbContext) },
                { typeof(Driver), new BaseRepository<Driver>(appDbContext) },
                { typeof(Passenger), new BaseRepository<Passenger>(appDbContext) },
                { typeof(Permission), new BaseRepository<Permission>(appDbContext) },
                { typeof(Role), new BaseRepository<Role>(appDbContext) },
                { typeof(RolesPermission), new BaseRepository<RolesPermission>(appDbContext) },
                { typeof(DocumentType), new BaseRepository<DocumentType>(appDbContext) },
                { typeof(DrivingLicenseType), new BaseRepository<DrivingLicenseType>(appDbContext) }
            };
        }
        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_appDbContext);
        public IRepository<People> PeopleRepository => _peopleRepository ?? new BaseRepository<People>(_appDbContext);

        public IRepository<T> GetRepository<T>() where T : BaseEntity
        {
            if (_repositories.TryGetValue(typeof(T), out var repository))
            {
                return (IRepository<T>)repository;
            }

            throw new InvalidOperationException($"Repository not found for type {typeof(T).Name}");
        }
        public void Dispose()
        {
            _appDbContext?.Dispose();
        }

        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }

    

}
