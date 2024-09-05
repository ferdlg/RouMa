
using AutoMapper;
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

    public class PermissionController : ControllerBase
    {
        private readonly IService<Permission> _permissionService;
        private readonly IMapper _mapper;

        public PermissionController(IService<Permission> permissionService, IMapper mapper)
        {
            _permissionService = permissionService;
            _mapper = mapper;
        }
        //Request to get all permissions

        [HttpGet]
        public IActionResult GetAll()
        {
            var permission =  _permissionService.GetAll();
            var permissionDto = _mapper.Map<IEnumerable<PermissionDto>>(permission);
            var response = new ApiResponse<IEnumerable<PermissionDto>>(permissionDto);
            return Ok(response);
        }
        //Request to get permission by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var permission = await _permissionService.GetById(id);
            var permissionDto = _mapper.Map<PermissionDto>(permission);
            var response = new ApiResponse<PermissionDto>(permissionDto);

            return Ok(response);
        }

        //Request to create permission

        [HttpPost]

        public async Task<IActionResult> Add(PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            await _permissionService.Add(permission);

            permissionDto = _mapper.Map<PermissionDto>(permission);
            var response = new ApiResponse<PermissionDto>(permissionDto);
            return Ok(response);
        }
        //Request to update permission
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, PermissionDto permissionDto)
        {
            var permission = _mapper.Map<Permission>(permissionDto);
            permission.Id = id;

            var result = await _permissionService.Update(permission);
            var response =  new ApiResponse<Permission>(result);
            return Ok(response);
        }
        //Request to remove permission by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Deletepermission(int id)
        {
           var result = await _permissionService.Delete(id);
           var response = new ApiResponse<Permission>(result);

           return Ok(response);
        }

    } 
}

