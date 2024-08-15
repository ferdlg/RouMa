using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task PostEmployee(Employee Employee);
        Task<bool> UpdateEmployee(Employee employee);

        Task<bool> DeleteEmployee(int id);
    }
}
