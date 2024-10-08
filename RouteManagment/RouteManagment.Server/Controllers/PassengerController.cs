
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

    public class PassengerController : ControllerBase
    {
        private readonly IServiceP<Passenger> _PassengerService;
        private readonly IMapper _mapper;

        public PassengerController(IServiceP<Passenger> PassengerService, IMapper mapper)
        {
            _PassengerService = PassengerService;
            _mapper = mapper;
        }
        //Request to get all Passengers

        [HttpGet]
        public IActionResult GetAll()
        {
            var passenger =  _PassengerService.GetAll();
            var PassengerDto = _mapper.Map<IEnumerable<PassengerDto>>(passenger);
            var response = new ApiResponse<IEnumerable<PassengerDto>>(PassengerDto);
            return Ok(response);
        }
        //Request to get Passenger by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var passenger = await _PassengerService.GetById(id);
            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            var response = new ApiResponse<PassengerDto>(passengerDto);
            return Ok(response);
        }

        //Request to create Passenger

        [HttpPost]

        public async Task<IActionResult> Add(PassengerDto passengerDto)
        {
            var passenger = _mapper.Map<Passenger>(passengerDto);
            await _PassengerService.Add(passenger);

            passengerDto = _mapper.Map<PassengerDto>(passengerDto);
            var response = new ApiResponse<PassengerDto>(passengerDto);
            return Ok(response);
        }

        //Request to update passenger
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, PassengerDto passengerDto)
        {
            var passenger = _mapper.Map<Passenger>(passengerDto);
            passenger.Id = id;

            var result= await _PassengerService.Update(passenger);
            var response = new ApiResponse<Passenger>(result);
            return Ok(response);
        }
        //Request to remove passenger by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           var result= await _PassengerService.Delete(id);
           var response = new ApiResponse<Passenger>(result);
           return Ok(response);
         
        }

    } 
}

