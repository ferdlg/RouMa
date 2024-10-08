
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Responses;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class DriverController : ControllerBase
    {
        private readonly IServiceP<Driver> _DriverService;
        private readonly IMapper _mapper;

        public DriverController(IServiceP<Driver> DriverService, IMapper mapper)
        {
            _DriverService = DriverService;
            _mapper = mapper;
        }
        //Request to get all Drivers

        [HttpGet]
        public IActionResult GetAll()
        {
            var Driver =  _DriverService.GetAll();
            var DriverDto = _mapper.Map<IEnumerable<DriverDto>>(Driver);

            var response = new ApiResponse<IEnumerable<DriverDto>>(DriverDto);
            return Ok(response);
        }
        //Request to get Driver by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var Driver = await _DriverService.GetById(id);
            var driverDto = _mapper.Map<DriverDto>(Driver);
            var response = new ApiResponse<DriverDto>(driverDto);
            return Ok(response);
        }

        //Request to create Driver

        [HttpPost]

        public async Task<IActionResult> Add(DriverDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);
            await _DriverService.Add(driver);

            driverDto = _mapper.Map<DriverDto>(driver);
            var response = new ApiResponse<DriverDto>(driverDto);
            return Ok(response);
        }

        //Request to update driver
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, DriverDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);
            driver.Id = id;

            var result = await _DriverService.Update(driver);
            var respose = new ApiResponse<Driver>(result);
            return Ok(respose);
        }
        //Request to remove driver by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           var result = await _DriverService.Delete(id);
           var respose = new ApiResponse<Driver>(result);
           return Ok(respose);
        
        }

    } 
}

