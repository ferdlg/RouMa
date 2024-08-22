
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

    public class PermissionController : ControllerBase
    {
        private readonly IRepository<Permission> _PermissionRepository;
        private readonly IMapper _mapper;

        public PermissionController(IRepository<Permission> permissionRepository, IMapper mapper)
        {
            _PermissionRepository = permissionRepository;
            _mapper = mapper;
        }
        //Request to get all permissions

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permission = await _PermissionRepository.GetAll();
            var permissionDto = _mapper.Map<IEnumerable<PermissionDto>>(permission);
            return Ok(permissionDto);
        }
        //Request to get permission by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var permission = await _PermissionRepository.GetById(id);
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            return Ok(permissionDto);
        }

        //Request to create permission

        [HttpPost]

        public async Task<IActionResult> Add(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _PermissionRepository.Add(permission);
            return Ok(permission);
        }
        //Request to update permission
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            permission.Id = id;

            await _PermissionRepository.Update(permission);
            return Ok(permission);
        }
        //Request to remove permission by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Deletepermission(int id)
        {
            {

                await _PermissionRepository.Delete(id);
                return Ok();
            }
        }

    } 
}

