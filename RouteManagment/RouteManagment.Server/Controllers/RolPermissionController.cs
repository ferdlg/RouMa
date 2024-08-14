
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

    public class RolPermissionController : ControllerBase
    {
        private readonly IRolPermissionRepository _RolPermissionRepository;
        private readonly IMapper _mapper;

        public RolPermissionController(IRolPermissionRepository RolPermissionRepository, IMapper mapper)
        {
            _RolPermissionRepository = RolPermissionRepository;
            _mapper = mapper;
        }
        //Request to get all RolPermissions

        [HttpGet]
        public async Task<IActionResult> GetRolPermissions()
        {
            var rolPermission = await _RolPermissionRepository.GetRolPermissions();
            var rolPermissionDto = _mapper.Map<IEnumerable<RolPermisionDto>>(rolPermission);
            return Ok(rolPermissionDto);
        }
        //Request to get RolPermission by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetRolPermission(int id)
        {
            var rolPermission = await _RolPermissionRepository.GetRolPermission(id);
            var rolPermissionDto = _mapper.Map<RolPermisionDto>(rolPermission);
            return Ok(rolPermissionDto);
        }

        //Request to create RolPermission

        [HttpPost]

        public async Task<IActionResult> PostRolPermission(RolPermisionDto rolPermissionDto)
        {
            var rolPermission = _mapper.Map<RolesPermission>(rolPermissionDto);
            await _RolPermissionRepository.PostRolPermission(rolPermission);
            return Ok(rolPermission);
        }

        //Request to update RolPermission
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRolPermission(int id)
        {
            var rolPermission = await _RolPermissionRepository.PutRolPermission(id);
            var rolPermissionDto = _mapper.Map<RolPermisionDto>(rolPermission);
            return Ok(rolPermissionDto);
        }

        //Request to remove RolPermission 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRolPermission(int id)
        {
            var rolPermission = await _RolPermissionRepository.DeleteRolPermission(id);
            var rolPermissionDto = _mapper.Map<RolPermisionDto>(rolPermission);
            return Ok(rolPermissionDto);
        }

    } 
}

