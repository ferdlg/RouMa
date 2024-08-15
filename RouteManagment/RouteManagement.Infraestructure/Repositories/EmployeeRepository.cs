using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class  EmployeeRepository : IEmployeeRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all Employees
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _appDbContext.Employees.ToListAsync();
            return employees;
        }

        //List Employee by id 
        public async Task<Employee> GetEmployee(int id)
        {
            var employee = await _appDbContext.Employees.FirstOrDefaultAsync(Employee_x => Employee_x.DocumentNumber == id);
            return employee;
        }

        // Create Employee

        public async Task PostEmployee(Employee employee)
        {
            _appDbContext.Employees.Add(employee);
            await _appDbContext.SaveChangesAsync();

        }

        // Update employee by id 
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var up_employee = await GetEmployee(employee.DocumentNumber);
            up_employee.DocumentNumber = employee.DocumentNumber;
            up_employee.FirstName = employee.FirstName;
            up_employee.LastName = employee.LastName;
            up_employee.Email = employee.Email;
            up_employee.Phone = employee.Phone;
            up_employee.AddressId = employee.AddressId;
            up_employee.DocumentTypeId = employee.DocumentTypeId;
            up_employee.RolId = employee.RolId;
            up_employee.CompanyId = employee.CompanyId;
            up_employee.TransportPlate = employee.TransportPlate;


            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove employee by id
        public async Task<bool> DeleteEmployee(int id)
        {
            var up_employee = await GetEmployee(id);
            _appDbContext.Employees.Remove(up_employee);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
