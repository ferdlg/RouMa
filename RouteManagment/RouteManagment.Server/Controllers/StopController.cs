
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

    public class StopController : ControllerBase
    {
        private readonly IRepository<Stop> _stopRepository;
        private readonly IMapper _mapper;

        public StopController(IRepository<Stop> stopRepository, IMapper mapper)
        {
            _stopRepository = stopRepository;
            _mapper = mapper;
        }
        //Request to get all stops

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var stops = await _stopRepository.GetAll();
            var stopsDto = _mapper.Map<IEnumerable<StopDto>>(stops);
            return Ok(stopsDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var stop = await _stopRepository.GetById(id);
            var stopDto = _mapper.Map<StopDto>(stop);
            return Ok(stop);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(StopDto topDto)
        {
            var stop = _mapper.Map<Stop>(topDto);
            await _stopRepository.Add(stop);
            return Ok(stop);
        }
        //Request to update stop
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, StopDto stopDto)
        {
            var stop = _mapper.Map<Stop>(stopDto);
            stop.Id = id;

            await _stopRepository.Update(stop);
            return Ok(stop);
        }
        //Request to remove stop by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _stopRepository.Delete(id);
                return Ok();
            }
        }
    }
}

