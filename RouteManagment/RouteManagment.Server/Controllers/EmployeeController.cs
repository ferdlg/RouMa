
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IMapper _mapper;

        public EmployeeController(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }
        //Request to get all Employees

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var Employee = await _EmployeeRepository.GetEmployees();
            var EmployeeDto = _mapper.Map<IEnumerable<EmployeeDto>>(Employee);
            return Ok(EmployeeDto);
        }
        //Request to get Employee by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _EmployeeRepository.GetEmployee(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        //Request to create Employee

        [HttpPost]

        public async Task<IActionResult> PostEmployee(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _EmployeeRepository.PostEmployee(employee);
            return Ok(employee);
        }

        //Request to update Employee
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id)
        {
            var employee = await _EmployeeRepository.PutEmployee(id);
            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        //Request to remove Employee 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var Employee = await _EmployeeRepository.DeleteEmployee(id);
            var documenTypeDto = _mapper.Map<EmployeeDto>(Employee);
            return Ok(documenTypeDto);
        }

    } 
}

