
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

    public class RouteController : ControllerBase
    {
        private readonly IRepository<Core.Entities.Route> _RouteRepository;
        private readonly IMapper _mapper;

        public RouteController(IRepository<Core.Entities.Route> routeRepository, IMapper mapper)
        {
            _RouteRepository = routeRepository;
            _mapper = mapper;
        }
        //Request to get all Routes

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var route = await _RouteRepository.GetAll();
            var routeDto = _mapper.Map<IEnumerable<RouteDto>>(route);
            return Ok(routeDto);
        }
        //Request to get Route by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var route = await _RouteRepository.GetById(id);
            var routeDto = _mapper.Map<RouteDto>(route);
            return Ok(route);
        }

        //Request to create Route

        [HttpPost]

        public async Task<IActionResult> Add(RouteDto routeDto)
        {
            var route = _mapper.Map<Core.Entities.Route>(routeDto);
            await _RouteRepository.Add(route);
            return Ok(route);
        }

        //Request to update route
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RouteDto routeDto)
        {
            var route = _mapper.Map<Core.Entities.Route>(routeDto);
            route.Id = id;

            await _RouteRepository.Update(route);
            return Ok(route);
        }
        //Request to remove route by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _RouteRepository.Delete(id);
                return Ok();
            }
        }

    } 
}

