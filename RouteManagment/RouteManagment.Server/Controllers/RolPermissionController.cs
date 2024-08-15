
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

        //Request to update rolPermission
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdaterolPermission(int id, RolPermisionDto rolPermissionDto)
        {
            var rolPermission = _mapper.Map<RolesPermission>(rolPermissionDto);
            rolPermission.RolPermissionId = id;

            await _RolPermissionRepository.UpdateRolPermission(rolPermission);
            return Ok(rolPermission);
        }
        //Request to remove rolPermission by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleterolPermission(int id)
        {
            {

                var result = await _RolPermissionRepository.DeleteRolPermission(id);
                return Ok(result);
            }
        }

    } 
}

