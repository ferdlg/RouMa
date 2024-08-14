
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

    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRepository _PassengerRepository;
        private readonly IMapper _mapper;

        public PassengerController(IPassengerRepository PassengerRepository, IMapper mapper)
        {
            _PassengerRepository = PassengerRepository;
            _mapper = mapper;
        }
        //Request to get all Passengers

        [HttpGet]
        public async Task<IActionResult> GetPassengers()
        {
            var passenger = await _PassengerRepository.GetPassengers();
            var PassengerDto = _mapper.Map<IEnumerable<PassengerDto>>(passenger);
            return Ok(PassengerDto);
        }
        //Request to get Passenger by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPassenger(int id)
        {
            var passenger = await _PassengerRepository.GetPassenger(id);
            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            return Ok(passengerDto);
        }

        //Request to create Passenger

        [HttpPost]

        public async Task<IActionResult> PostPassenger(PassengerDto PassengerDto)
        {
            var passenger = _mapper.Map<Passenger>(PassengerDto);
            await _PassengerRepository.PostPassenger(passenger);
            return Ok(passenger);
        }

        //Request to update Passenger
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger(int id)
        {
            var passenger = await _PassengerRepository.PutPassenger(id);
            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            return Ok(passengerDto);
        }

        //Request to remove Passenger 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var passenger = await _PassengerRepository.DeletePassenger(id);
            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            return Ok(passengerDto);
        }

    } 
}

