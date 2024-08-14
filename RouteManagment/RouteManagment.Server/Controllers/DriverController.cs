
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

    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _DriverRepository;
        private readonly IMapper _mapper;

        public DriverController(IDriverRepository DriverRepository, IMapper mapper)
        {
            _DriverRepository = DriverRepository;
            _mapper = mapper;
        }
        //Request to get all Drivers

        [HttpGet]
        public async Task<IActionResult> GetDrivers()
        {
            var Driver = await _DriverRepository.GetDrivers();
            var DriverDto = _mapper.Map<IEnumerable<DriverDto>>(Driver);
            return Ok(DriverDto);
        }
        //Request to get Driver by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetDriver(int id)
        {
            var Driver = await _DriverRepository.GetDriver(id);
            var documenTypeDto = _mapper.Map<DriverDto>(Driver);
            return Ok(Driver);
        }

        //Request to create Driver

        [HttpPost]

        public async Task<IActionResult> PostDriver(DriverDto DriverDto)
        {
            var Driver = _mapper.Map<Driver>(DriverDto);
            await _DriverRepository.PostDriver(Driver);
            return Ok(Driver);
        }

        //Request to update Driver
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriver(int id)
        {
            var Driver = await _DriverRepository.PutDriver(id);
            var documenTypeDto = _mapper.Map<DriverDto>(Driver);
            return Ok(documenTypeDto);
        }

        //Request to remove Driver 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            var Driver = await _DriverRepository.DeleteDriver(id);
            var documenTypeDto = _mapper.Map<DriverDto>(Driver);
            return Ok(documenTypeDto);
        }

    } 
}

