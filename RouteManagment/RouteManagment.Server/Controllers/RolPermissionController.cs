
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;



namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class RolPermissionController : ControllerBase
    {
        private readonly IRepository<RolesPermission> _RolPermissionRepository;
        private readonly IMapper _mapper;

        public RolPermissionController(IRepository<RolesPermission>  RolPermissionRepository, IMapper mapper)
        {
            _RolPermissionRepository = RolPermissionRepository;
            _mapper = mapper;
        }
        //Request to get all RolPermissions

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rolPermission = await _RolPermissionRepository.GetAll();
            var rolPermissionDto = _mapper.Map<IEnumerable<RolPermisionDto>>(rolPermission);
            return Ok(rolPermissionDto);
        }
        //Request to get RolPermission by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var rolPermission = await _RolPermissionRepository.GetById(id);
            var rolPermissionDto = _mapper.Map<RolPermisionDto>(rolPermission);
            return Ok(rolPermissionDto);
        }

        //Request to create RolPermission

        [HttpPost]

        public async Task<IActionResult> Add(RolPermisionDto rolPermissionDto)
        {
            var rolPermission = _mapper.Map<RolesPermission>(rolPermissionDto);
            await _RolPermissionRepository.Add(rolPermission);
            return Ok(rolPermission);
        }

        //Request to update rolPermission
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RolPermisionDto rolPermissionDto)
        {
            var rolPermission = _mapper.Map<RolesPermission>(rolPermissionDto);
            rolPermission.Id = id;

            await _RolPermissionRepository.Update(rolPermission);
            return Ok(rolPermission);
        }
        //Request to remove rolPermission by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _RolPermissionRepository.Delete(id);
                return Ok();
            }
        }

    } 
}

