
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

    public class RoleController : ControllerBase
    {
        private readonly IRolRepository _RolRepository;
        private readonly IMapper _mapper;

        public RoleController(IRolRepository RolRepository, IMapper mapper)
        {
            _RolRepository = RolRepository;
            _mapper = mapper;
        }
        //Request to get all Roles

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            var Role = await _RolRepository.GetRoles();
            var RolDto = _mapper.Map<IEnumerable<RolDto>>(Role);
            return Ok(RolDto);
        }
        //Request to get Role by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetRol(int id)
        {
            var Role = await _RolRepository.GetRol(id);
            var RolDto = _mapper.Map<RolDto>(Role);
            return Ok(RolDto);
        }

        //Request to create Role

        [HttpPost]

        public async Task<IActionResult> PostRol(RolDto RolDto)
        {
            var role = _mapper.Map<Role>(RolDto);
            await _RolRepository.PostRol(role);
            return Ok(role);
        }

        //Request to update Role
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRol(int id)
        {
            var Role = await _RolRepository.PutRol(id);
            var RolDto = _mapper.Map<RolDto>(Role);
            return Ok(RolDto);
        }

        //Request to remove Role 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRol(int id)
        {
            var Role = await _RolRepository.DeleteRol(id);
            var RolDto = _mapper.Map<RolDto>(Role);
            return Ok(RolDto);
        }

    } 
}

