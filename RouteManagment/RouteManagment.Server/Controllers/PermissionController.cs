
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

    public class PermissionController : ControllerBase
    {
        private readonly IPermissionRepository _PermissionRepository;
        private readonly IMapper _mapper;

        public PermissionController(IPermissionRepository permissionRepository, IMapper mapper)
        {
            _PermissionRepository = permissionRepository;
            _mapper = mapper;
        }
        //Request to get all permissions

        [HttpGet]
        public async Task<IActionResult> GetPermissions()
        {
            var permission = await _PermissionRepository.GetPermissions();
            var permissionDto = _mapper.Map<IEnumerable<PermissionDto>>(permission);
            return Ok(permissionDto);
        }
        //Request to get permission by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPermission(int id)
        {
            var permission = await _PermissionRepository.GetPermission(id);
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            return Ok(permissionDto);
        }

        //Request to create permission

        [HttpPost]

        public async Task<IActionResult> PostPermission(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _PermissionRepository.PostPermission(permission);
            return Ok(permission);
        }

        //Request to update permission
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPermission(int id)
        {
            var permission = await _PermissionRepository.PutPermission(id);
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            return Ok(permissionDto);
        }

        //Request to remove permission 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePermission(int id)
        {
            var permission = await _PermissionRepository.DeletePermission(id);
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            return Ok(permissionDto);
        }

    } 
}

