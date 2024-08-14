
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class AdministratorController : ControllerBase
    {
        private readonly IAdministratorRepository _administratorRepository;
        private readonly IMapper _mapper;

        public AdministratorController(IAdministratorRepository administratorRepository, IMapper mapper)
        {
            _administratorRepository = administratorRepository;
            _mapper = mapper;
        }
        //Request to get all administrator

        [HttpGet]
        public async Task<IActionResult> GetAdministrators()
        {
            var administrators = await _administratorRepository.GetAdministrators();
            var administratorsDto = _mapper.Map<IEnumerable<AdministratorDto>>(administrators);

            return Ok(administratorsDto);
        }

        //Request to get administrator by id 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdministrator(int id)
        {
            var administrator = await _administratorRepository.GetAdministrator(id);
            var administratorDto = _mapper.Map<AdministratorDto>(administrator);
            return Ok(administrator);
        }

        //Request to create administrator
        [HttpPost]
        public async Task<IActionResult> PostAdministrator(AdministratorDto administratorDto)
        {
            var administrator = _mapper.Map<Administrator>(administratorDto);
            await _administratorRepository.PostAdministrator(administrator);
            return Ok(administrator);
        }

        //Request to update administrator
        [HttpPut("{id}")]

        public async Task<IActionResult> PutAdministrator(int id)
        {
            var administrator = await _administratorRepository.PutAdministrator(id);
            var administratorDto = _mapper.Map<AdministratorDto>(administrator);
            return Ok(administratorDto);
        }
        //Request to remove administrator by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAdministrator(int id)
        {
            {
                var administrator = await _administratorRepository.DeleteAdministrator(id);
                var administratorDto = _mapper.Map<AdministratorDto>(administrator);
                return Ok(administratorDto);
            }
        }

    }
}

