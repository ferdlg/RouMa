
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

    public class RoutesStopController : ControllerBase
    {
        private readonly IRouteStopRepository _routeStopRepository;
        private readonly IMapper _mapper;

        public RoutesStopController(IRouteStopRepository routeStopRepository, IMapper mapper)
        {
            _routeStopRepository = routeStopRepository;
            _mapper = mapper;
        }
        //Request to get all companies

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _routeStopRepository.GetRoutesStops();
            var companiesDto = _mapper.Map<IEnumerable<RouteStopDto>>(companies);
            return Ok(companiesDto);
        }
        //Request to get RouteStop by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCompanies(int id)
        {
            var RouteStop = await _routeStopRepository.GetRoutesStop(id);
            var RouteStopDto = _mapper.Map<RouteStopDto>(RouteStop);
            return Ok(RouteStop);
        }

        //Request to create RouteStop

        [HttpPost]

        public async Task<IActionResult> PostRouteStop(RouteStopDto RouteStopDto)
        {
            var RouteStop = _mapper.Map<RoutesStop>(RouteStopDto);
            await _routeStopRepository.PostRoutesStop(RouteStop);
            return Ok(RouteStop);
        }

        //Request to update RouteStop
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRouteStop(int id)
        {
            var RouteStop = await _routeStopRepository.PutRoutesStop(id);
            var RouteStopDto = _mapper.Map<RouteStopDto>(RouteStop);
            return Ok(RouteStopDto);
        }

        //Request to remove RouteStop 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRouteStop(int id)
        {
            var RouteStop = await _routeStopRepository.DeleteRoutesStop(id);
            var RouteStopDto = _mapper.Map<RouteStopDto>(RouteStop);

            return Ok(RouteStopDto);
        }
    }
}

