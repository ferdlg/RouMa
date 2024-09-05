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

    public interface IAdministratorService : IService<Administrator>
    {

    }
    public interface ICompanyService : IService<Company>
    {

    }
    public interface IDriverService : IService<Driver>
    {

    }
    public interface IPassengerService : IService<Passenger>
    {

    }
    public interface IPermissionService : IService<Permission>
    {

    }
    public interface IRolService : IService<Role>
    {

    }
    public interface IRolPermissionService : IService<RolesPermission>
    {

    }
    public interface IDocumentTypeService : IService<DocumentType>
    {

    }
    public interface IDrivingLicenseTypeService : IService<DrivingLicenseType>
    {

    }


}
