using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<IEnumerable<Administrator>> GetAdministrators();

        Task<Administrator> GetAdministrator(int id);

        Task PostAdministrator(Administrator administrator);
        Task<Administrator> PutAdministrator(int id);

        Task<Administrator> DeleteAdministrator(int id);
    }
}
