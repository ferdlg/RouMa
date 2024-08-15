using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface IAdministratorRepository
    {
        Task<IEnumerable<Administrator>> GetAdministrators();

        Task<Administrator> GetAdministrator(int id);

        Task PostAdministrator(Administrator administrator);
        Task<bool> UpdateAdministrator(Administrator administrator);

        Task<bool> DeleteAdministrator(int id);
    }
}
