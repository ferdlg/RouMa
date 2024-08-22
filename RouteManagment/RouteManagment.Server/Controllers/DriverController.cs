
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class DriverController : ControllerBase
    {
        private readonly IRepository<Driver> _DriverRepository;
        private readonly IMapper _mapper;

        public DriverController(IRepository<Driver> DriverRepository, IMapper mapper)
        {
            _DriverRepository = DriverRepository;
            _mapper = mapper;
        }
        //Request to get all Drivers

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Driver = await _DriverRepository.GetAll();
            var DriverDto = _mapper.Map<IEnumerable<DriverDto>>(Driver);
            return Ok(DriverDto);
        }
        //Request to get Driver by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var Driver = await _DriverRepository.GetById(id);
            var documenTypeDto = _mapper.Map<DriverDto>(Driver);
            return Ok(Driver);
        }

        //Request to create Driver

        [HttpPost]

        public async Task<IActionResult> Add(DriverDto DriverDto)
        {
            var Driver = _mapper.Map<Driver>(DriverDto);
            await _DriverRepository.Add(Driver);
            return Ok(Driver);
        }

        //Request to update driver
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, DriverDto driverDto)
        {
            var driver = _mapper.Map<Driver>(driverDto);
            driver.Id = id;

            await _DriverRepository.Update(driver);
            return Ok(driver);
        }
        //Request to remove driver by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _DriverRepository.Delete(id);
                return Ok();
            }
        }

    } 
}

