
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
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
        public IActionResult GetAll()
        {
            var stops =  _stopRepository.GetAll();
            var stopsDto = _mapper.Map<IEnumerable<StopDto>>(stops);
            var response = new ApiResponse<IEnumerable<StopDto>>(stopsDto);
            return Ok(response);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var stop = await _stopRepository.GetById(id);
            var stopDto = _mapper.Map<StopDto>(stop);
            var response = new ApiResponse<StopDto>(stopDto);
            return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(StopDto stopDto)
        {
            var stop = _mapper.Map<Stop>(stopDto);
            await _stopRepository.Add(stop);

            stopDto = _mapper.Map<StopDto>(stop);
            var response = new ApiResponse<StopDto>(stopDto);
            return Ok(response);
        }
        //Request to update stop
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, StopDto stopDto)
        {
            var stop = _mapper.Map<Stop>(stopDto);
            stop.Id = id;

            var result = await _stopRepository.Update(stop);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
        //Request to remove stop by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {

              var result = await _stopRepository.Delete(id);
              var response = new ApiResponse<bool>(result);
              return Ok();
            
        }
    }
}

