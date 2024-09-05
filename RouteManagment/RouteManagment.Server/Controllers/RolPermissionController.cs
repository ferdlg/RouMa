
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
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

    public class RolPermissionController : ControllerBase
    {
        private readonly IService<RolesPermission> _RolPermissionService;
        private readonly IMapper _mapper;

        public RolPermissionController(IService<RolesPermission>  RolPermissionService, IMapper mapper)
        {
            _RolPermissionService = RolPermissionService;
            _mapper = mapper;
        }
        //Request to get all RolPermissions

        [HttpGet]
        public IActionResult GetAll()
        {
            var rolPermission =  _RolPermissionService.GetAll();
            var rolPermissionDto = _mapper.Map<IEnumerable<RolPermisionDto>>(rolPermission);
            var response = new ApiResponse<IEnumerable<RolPermisionDto>>(rolPermissionDto);
            return Ok(response);
        }
        //Request to get RolPermission by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var rolPermission = await _RolPermissionService.GetById(id);
            var rolPermissionDto = _mapper.Map<RolPermisionDto>(rolPermission);
            var response = new ApiResponse<RolPermisionDto>(rolPermissionDto);

            return Ok(response);
        }

        //Request to create RolPermission

        [HttpPost]

        public async Task<IActionResult> Add(RolPermisionDto rolPermissionDto)
        {
            var rolPermission = _mapper.Map<RolesPermission>(rolPermissionDto);
            await _RolPermissionService.Add(rolPermission);

            rolPermissionDto = _mapper.Map<RolPermisionDto>(rolPermission);
            var response = new ApiResponse<RolPermisionDto>(rolPermissionDto);
            return Ok(response);
        }

        //Request to update rolPermission
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RolPermisionDto rolPermissionDto)
        {
            var rolPermission = _mapper.Map<RolesPermission>(rolPermissionDto);
            rolPermission.Id = id;

            var result= await _RolPermissionService.Update(rolPermission);
            var response = new ApiResponse<RolesPermission>(result);
            return Ok(response);
        }
        //Request to remove rolPermission by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
        

           var result= await _RolPermissionService.Delete(id);
           var response = new ApiResponse<RolesPermission>(result);
           return Ok(response);
        
        }

    } 
}

