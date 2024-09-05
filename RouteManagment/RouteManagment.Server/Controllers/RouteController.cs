
using AutoMapper;
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

    public class RouteController : ControllerBase
    {
        private readonly IRouteService _RouteService;
        private readonly IMapper _mapper;

        public RouteController(IRouteService routeService, IMapper mapper)
        {
            _RouteService = routeService;
            _mapper = mapper;
        }
        //Request to get all Routes

        [HttpGet]
        public IActionResult GetAll()
        {
            var route =  _RouteService.GetRoutes();
            var routeDto = _mapper.Map<IEnumerable<RouteDto>>(route);
            var response = new ApiResponse<IEnumerable<RouteDto>>(routeDto);
            return Ok(response);
        }
        //Request to get Route by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var route = await _RouteService.GetRouteById(id);
            var routeDto = _mapper.Map<RouteDto>(route);
            var response = new ApiResponse<RouteDto>(routeDto);

            return Ok(response);
        }

        //Request to create Route

        [HttpPost]

        public async Task<IActionResult> Add(RouteDto routeDto)
        {
            var route = _mapper.Map<Core.Entities.Route>(routeDto);
            await _RouteService.InsertRoute(route);

            routeDto = _mapper.Map<RouteDto>(route);
            var response = new ApiResponse<RouteDto>(routeDto);
            return Ok(response);
        }

        //Request to update route
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RouteDto routeDto)
        {
            var route = _mapper.Map<Core.Entities.Route>(routeDto);
            route.Id = id;

            var result = await _RouteService.Update(route);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        //Request to remove route by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           var result = await _RouteService.Delete(id);
           var response = new ApiResponse<bool>(result);
           return Ok(response);
            
        }

    } 
}

