
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

    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _PersonRepository;
        private readonly IMapper _mapper;

        public PeopleController(IPeopleRepository PersonRepository, IMapper mapper)
        {
            _PersonRepository = PersonRepository;
            _mapper = mapper;
        }
        //Request to get all Persons

        [HttpGet]
        public async Task<IActionResult> GetPeople()
        {
            var Person = await _PersonRepository.GetPeople();
            var PersonDto = _mapper.Map<IEnumerable<PeopleDto>>(Person);
            return Ok(PersonDto);
        }
        //Request to get Person by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPerson(int id)
        {
            var Person = await _PersonRepository.GetPerson(id);
            var PersonDto = _mapper.Map<PeopleDto>(Person);
            return Ok(PersonDto);
        }

        //Request to create Person

        [HttpPost]

        public async Task<IActionResult> PostPerson(PeopleDto PersonDto)
        {
            var Person = _mapper.Map<Person>(PersonDto);
            await _PersonRepository.PostPerson(Person);
            return Ok(Person);
        }

        //Request to update Person
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatePerson(int id, PeopleDto PersonDto)
        {
            var Person = _mapper.Map<Person>(PersonDto);
            Person.DocumentNumber= id;

            await _PersonRepository.UpdatePerson(Person);
            return Ok(Person);
        }
        //Request to remove Person by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletePerson(int id)
        {
            {

                var result = await _PersonRepository.DeletePerson(id);
                return Ok(result);
            }
        }

    } 
}

