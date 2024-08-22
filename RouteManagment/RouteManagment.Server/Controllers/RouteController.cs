
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    
    //Request Managment

    public class RouteController : ControllerBase
    {
        private readonly IRouteRepository _RouteRepository;
        private readonly IMapper _mapper;

        public RouteController(IRouteRepository routeRepository, IMapper mapper)
        {
            _RouteRepository = routeRepository;
            _mapper = mapper;
        }
        //Request to get all Routes

        [HttpGet]
        public async Task<IActionResult> GetRoutes()
        {
            var route = await _RouteRepository.GetRoutes();
            var routeDto = _mapper.Map<IEnumerable<RouteDto>>(route);
            return Ok(routeDto);
        }
        //Request to get Route by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetRoute(int id)
        {
            var route = await _RouteRepository.GetRoute(id);
            var routeDto = _mapper.Map<RouteDto>(route);
            return Ok(route);
        }

        //Request to create Route

        [HttpPost]

        public async Task<IActionResult> PostRoute(RouteDto routeDto)
        {
            var route = _mapper.Map<Core.Entities.Route>(routeDto);
            await _RouteRepository.PostRoute(route);
            return Ok(route);
        }

        //Request to update route
        [HttpPut("{id}")]

        public async Task<IActionResult> Updateroute(int id, RouteDto routeDto)
        {
            var route = _mapper.Map<Core.Entities.Route>(routeDto);
            route.Id = id;

            await _RouteRepository.UpdateRoute(route);
            return Ok(route);
        }
        //Request to remove route by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Deleteroute(int id)
        {
            {

                var result = await _RouteRepository.DeleteRoute(id);
                return Ok(result);
            }
        }

    } 
}

