
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
        public IActionResult GetAll()
        {
            var Person =  _PersonRepository.GetAll();
            var PersonDto = _mapper.Map<IEnumerable<PeopleDto>>(Person);
            var Response = new ApiResponse<IEnumerable<PeopleDto>>(PersonDto);
            return Ok(Response);
        }
        //Request to get Person by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var person = await _PersonRepository.GetById(id);
            var personDto = _mapper.Map<PeopleDto>(person);
            var response = new ApiResponse<PeopleDto>(personDto);
            return Ok(response);
        }

        //Request to create Person

        [HttpPost]

        public async Task<IActionResult> Add(PeopleDto personDto)
        {
            var person = _mapper.Map<People>(personDto);
            await _PersonRepository.Add(person);

            personDto = _mapper.Map<PeopleDto>(person);
            var response = new ApiResponse<PeopleDto>(personDto);
            return Ok(response);
        }

        //Request to update Person
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, PeopleDto personDto)
        {
            var person = _mapper.Map<People>(personDto);
            person.Id= id;

            var result = await _PersonRepository.Update(person);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        //Request to remove Person by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var repository =  await _PersonRepository.Delete(id);
            var response = new ApiResponse<bool>(repository);
            return Ok(response);
            
        }

    } 
}

