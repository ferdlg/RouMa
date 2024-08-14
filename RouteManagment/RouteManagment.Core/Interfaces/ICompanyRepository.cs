using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;

namespace ManejoRutas.Core.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompany(int id);
        Task PostCompany(Company Company);
        Task<Company> PutCompany(int id);

        Task<Company> DeleteCompany(int id);

    }
}
