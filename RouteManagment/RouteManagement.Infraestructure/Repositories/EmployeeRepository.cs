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

        //Update Employee 

        public async Task<Employee> PutEmployee(int id)
        {
            var employee = _appDbContext.Employees.FirstOrDefaultAsync(Employee_x => Employee_x.DocumentNumber == id);
            _appDbContext.Employees.Update(await employee);
            await _appDbContext.SaveChangesAsync();
            return await employee;
        }

        //Remove Employee by id 

        public async Task<Employee> DeleteEmployee(int id)
        {
            var employee = await _appDbContext.Employees.FirstOrDefaultAsync(Employee_x => Employee_x.DocumentNumber == id);
            _appDbContext.Employees.Remove(employee);
            await _appDbContext.SaveChangesAsync();
            return employee;
        }
    }
}
