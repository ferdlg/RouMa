
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class PeopleController : ControllerBase
    {
        private readonly IRepository<People> _PersonRepository;
        private readonly IMapper _mapper;

        public PeopleController(IRepository<People> PersonRepository, IMapper mapper)
        {
            _PersonRepository = PersonRepository;
            _mapper = mapper;
        }
        //Request to get all Persons

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Person = await _PersonRepository.GetAll();
            var PersonDto = _mapper.Map<IEnumerable<PeopleDto>>(Person);
            return Ok(PersonDto);
        }
        //Request to get Person by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var Person = await _PersonRepository.GetById(id);
            var PersonDto = _mapper.Map<PeopleDto>(Person);
            return Ok(PersonDto);
        }

        //Request to create Person

        [HttpPost]

        public async Task<IActionResult> Add(PeopleDto PersonDto)
        {
            var Person = _mapper.Map<People>(PersonDto);
            await _PersonRepository.Add(Person);
            return Ok(Person);
        }

        //Request to update Person
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, PeopleDto PersonDto)
        {
            var Person = _mapper.Map<People>(PersonDto);
            Person.Id= id;

            await _PersonRepository.Update(Person);
            return Ok(Person);
        }
        //Request to remove Person by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
              await _PersonRepository.Delete(id);
              return Ok();
            
        }

    } 
}

