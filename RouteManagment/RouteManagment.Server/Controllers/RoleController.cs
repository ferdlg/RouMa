
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

    public class RoleController : ControllerBase
    {
        private readonly IRepository<Role> _RolRepository;
        private readonly IMapper _mapper;

        public RoleController(IRepository<Role> RolRepository, IMapper mapper)
        {
            _RolRepository = RolRepository;
            _mapper = mapper;
        }
        //Request to get all Roles

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Role = await _RolRepository.GetAll();
            var RolDto = _mapper.Map<IEnumerable<RolDto>>(Role);
            return Ok(RolDto);
        }
        //Request to get Role by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var Role = await _RolRepository.GetById(id);
            var RolDto = _mapper.Map<RolDto>(Role);
            return Ok(RolDto);
        }

        //Request to create Role

        [HttpPost]

        public async Task<IActionResult> Add(RolDto RolDto)
        {
            var role = _mapper.Map<Role>(RolDto);
            await _RolRepository.Add(role);
            return Ok(role);
        }

        //Request to update rol
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RolDto rolDto)
        {
            var rol = _mapper.Map<Role>(rolDto);
            rol.Id = id;

            await _RolRepository.Update(rol);
            return Ok(rol);
        }
        //Request to remove rol by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _RolRepository.Delete(id);
                return Ok();
            }
        }

    } 
}

