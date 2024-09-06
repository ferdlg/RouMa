
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

    public class RoutesStopController : ControllerBase
    {
        private readonly IServiceR<RoutesStop> _routeStopRepository;
        private readonly IMapper _mapper;

        public RoutesStopController(IServiceR<RoutesStop> routeStopRepository, IMapper mapper)
        {
            _routeStopRepository = routeStopRepository;
            _mapper = mapper;
        }
        //Request to get all companies

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies =  _routeStopRepository.GetAll();
            var companiesDto = _mapper.Map<IEnumerable<RouteStopDto>>(companies);
            var response = new ApiResponse<IEnumerable<RouteStopDto>>(companiesDto);
            return Ok(response);
        }
        //Request to get RouteStop by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var RouteStop = await _routeStopRepository.GetById(id);
            var RouteStopDto = _mapper.Map<RouteStopDto>(RouteStop);
            var response = new ApiResponse<RouteStopDto>(RouteStopDto);

            return Ok(response);
        }

        //Request to create RouteStop

        [HttpPost]

        public async Task<IActionResult> Add(RouteStopDto routeStopDto)
        {
            var routeStop = _mapper.Map<RoutesStop>(routeStopDto);
            await _routeStopRepository.Add(routeStop);

            routeStopDto = _mapper.Map<RouteStopDto>(routeStop);
            var response = new ApiResponse<RouteStopDto>(routeStopDto);
            return Ok(response);
        }

        //Request to update routeStop
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RouteStopDto routeStopDto)
        {
            var routeStop = _mapper.Map<RoutesStop>(routeStopDto);
            routeStop.Id = id;

            var result = await _routeStopRepository.Update(routeStop);
            var response = new ApiResponse<RoutesStop>(result);
            return Ok(response);
        }
        //Request to remove routeStop by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           var repository = await _routeStopRepository.Delete(id);
           var response = new ApiResponse<RoutesStop>(repository);
           return Ok(response);
        
        }
    }
}

