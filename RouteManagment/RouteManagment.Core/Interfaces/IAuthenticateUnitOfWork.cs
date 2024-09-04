using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.Interfaces
{
    public interface IAuthenticateUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Role> RoleRepository { get; }
        IRepository<Permission> PermissionRepository { get; }
        IRepository<RolesPermission> RolesPermissionRepository { get; }
        IRepository<Administrator> AdministratorRepository { get; }
        IRepository<Company> CompanyRepository { get; }
        IRepository<Driver> DriverRepository { get; }
        IRepository<Passenger> PassengerRepository { get; }
        IRepository<People> PeopleRepository { get; }

        void SaveChanges();
        Task SaveChangesAsync();
    }
}
