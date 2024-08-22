
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;


namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class AdministratorController : ControllerBase
    {
        private readonly IRepository<Administrator> _administratorRepository;
        private readonly IMapper _mapper;

        public AdministratorController(IRepository<Administrator> administratorRepository, IMapper mapper)
        {
            _administratorRepository = administratorRepository;
            _mapper = mapper;
        }
        //Request to get all administrator

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var administrators = await _administratorRepository.GetAll();
            var administratorsDto = _mapper.Map<IEnumerable<AdministratorDto>>(administrators);

            return Ok(administratorsDto);
        }

        //Request to get administrator by id 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var administrator = await _administratorRepository.GetById(id);
            var administratorDto = _mapper.Map<AdministratorDto>(administrator);
            return Ok(administrator);
        }

        //Request to create administrator
        [HttpPost]
        public async Task<IActionResult> Add(AdministratorDto administratorDto)
        {
            var administrator = _mapper.Map<Administrator>(administratorDto);
            await _administratorRepository.Add(administrator);
            return Ok(administrator);
        }

        //Request to update administrator
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, AdministratorDto administratorDto)
        {
            var administrator = _mapper.Map<Administrator>(administratorDto);
            administrator.Id = id;

            await _administratorRepository.Update(administrator);
            return Ok(administrator);
        }
        //Request to remove administrator by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _administratorRepository.Delete(id);
                return Ok();
            }
        }

    }
}

