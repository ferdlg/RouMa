
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

    public class PassengerController : ControllerBase
    {
        private readonly IRepository<Passenger> _PassengerRepository;
        private readonly IMapper _mapper;

        public PassengerController(IRepository<Passenger> PassengerRepository, IMapper mapper)
        {
            _PassengerRepository = PassengerRepository;
            _mapper = mapper;
        }
        //Request to get all Passengers

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var passenger = await _PassengerRepository.GetAll();
            var PassengerDto = _mapper.Map<IEnumerable<PassengerDto>>(passenger);
            return Ok(PassengerDto);
        }
        //Request to get Passenger by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var passenger = await _PassengerRepository.GetById(id);
            var passengerDto = _mapper.Map<PassengerDto>(passenger);
            return Ok(passengerDto);
        }

        //Request to create Passenger

        [HttpPost]

        public async Task<IActionResult> Add(PassengerDto PassengerDto)
        {
            var passenger = _mapper.Map<Passenger>(PassengerDto);
            await _PassengerRepository.Add(passenger);
            return Ok(passenger);
        }

        //Request to update passenger
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, PassengerDto passengerDto)
        {
            var passenger = _mapper.Map<Passenger>(passengerDto);
            passenger.Id = id;

            await _PassengerRepository.Update(passenger);
            return Ok(passenger);
        }
        //Request to remove passenger by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _PassengerRepository.Delete(id);
                return Ok();
            }
        }

    } 
}

