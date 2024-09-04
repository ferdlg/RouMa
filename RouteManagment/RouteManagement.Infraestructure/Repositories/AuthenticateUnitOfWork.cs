using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagement.Infraestructure.Repositories
{
    public class AuthenticateUnitOfWork(AppDbContext appDbContext) : IAuthenticateUnitOfWork
    {
        private readonly AppDbContext _appDbContext = appDbContext;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Role> _roleRepository;
        private readonly IRepository<Permission> _permissionRepository;
        private readonly IRepository<RolesPermission> _rolesPermissionRepository;
        private readonly IRepository<Administrator> _administratorRepository;
        private readonly IRepository<Company> _companyRepository;
        private readonly IRepository<Driver> _driverRepository;
        private readonly IRepository<Passenger> _passengerRepository;
        private readonly IRepository<People> _peopleRepository;

        public IRepository<User> UserRepository => _userRepository ?? new BaseRepository<User>(_appDbContext);

        public IRepository<Role> RoleRepository => _roleRepository ?? new BaseRepository<Role>(_appDbContext);

        public IRepository<Permission> PermissionRepository => _permissionRepository ?? new BaseRepository<Permission>(_appDbContext);

        public IRepository<RolesPermission> RolesPermissionRepository => _rolesPermissionRepository ?? new BaseRepository<RolesPermission>(_appDbContext);

        public IRepository<Administrator> AdministratorRepository => _administratorRepository ?? new BaseRepository<Administrator>(_appDbContext);

        public IRepository<Company> CompanyRepository => _companyRepository ?? new BaseRepository<Company>(_appDbContext);

        public IRepository<Driver> DriverRepository => _driverRepository ?? new BaseRepository<Driver>(_appDbContext);

        public IRepository<Passenger> PassengerRepository => _passengerRepository ?? new BaseRepository<Passenger>(_appDbContext);

        public IRepository<People> PeopleRepository => _peopleRepository ?? new BaseRepository<People>(_appDbContext);

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
