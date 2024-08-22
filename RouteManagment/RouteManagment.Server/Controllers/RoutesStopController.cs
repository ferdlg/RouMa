
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;


namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class RoutesStopController : ControllerBase
    {
        private readonly IRepository<RoutesStop> _routeStopRepository;
        private readonly IMapper _mapper;

        public RoutesStopController(IRepository<RoutesStop> routeStopRepository, IMapper mapper)
        {
            _routeStopRepository = routeStopRepository;
            _mapper = mapper;
        }
        //Request to get all companies

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var companies = await _routeStopRepository.GetAll();
            var companiesDto = _mapper.Map<IEnumerable<RouteStopDto>>(companies);
            return Ok(companiesDto);
        }
        //Request to get RouteStop by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var RouteStop = await _routeStopRepository.GetById(id);
            var RouteStopDto = _mapper.Map<RouteStopDto>(RouteStop);
            return Ok(RouteStop);
        }

        //Request to create RouteStop

        [HttpPost]

        public async Task<IActionResult> Add(RouteStopDto RouteStopDto)
        {
            var RouteStop = _mapper.Map<RoutesStop>(RouteStopDto);
            await _routeStopRepository.Add(RouteStop);
            return Ok(RouteStop);
        }

        //Request to update routeStop
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RouteStopDto routeStopDto)
        {
            var routeStop = _mapper.Map<RoutesStop>(routeStopDto);
            routeStop.Id = id;

            await _routeStopRepository.Update(routeStop);
            return Ok(routeStop);
        }
        //Request to remove routeStop by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _routeStopRepository.Delete(id);
                return Ok();
            }
        }
    }
}

