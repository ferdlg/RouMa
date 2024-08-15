
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

    public class StopController : ControllerBase
    {
        private readonly IStopRepository _stopRepository;
        private readonly IMapper _mapper;

        public StopController(IStopRepository stopRepository, IMapper mapper)
        {
            _stopRepository = stopRepository;
            _mapper = mapper;
        }
        //Request to get all stops

        [HttpGet]
        public async Task<IActionResult> Getstops()
        {
            var stops = await _stopRepository.GetStops();
            var stopsDto = _mapper.Map<IEnumerable<StopDto>>(stops);
            return Ok(stopsDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> Getstops(int id)
        {
            var stop = await _stopRepository.GetStop(id);
            var stopDto = _mapper.Map<StopDto>(stop);
            return Ok(stop);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(StopDto topDto)
        {
            var stop = _mapper.Map<Stop>(topDto);
            await _stopRepository.PostStop(stop);
            return Ok(stop);
        }
        //Request to update stop
        [HttpPut("{id}")]

        public async Task<IActionResult> Updatestop(int id, StopDto stopDto)
        {
            var stop = _mapper.Map<Stop>(stopDto);
            stop.StopId = id;

            await _stopRepository.UpdateStop(stop);
            return Ok(stop);
        }
        //Request to remove stop by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Deletestop(int id)
        {
            {

                var result = await _stopRepository.DeleteStop(id);
                return Ok(result);
            }
        }
    }
}

