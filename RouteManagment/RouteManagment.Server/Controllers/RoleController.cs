
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
        public IActionResult GetAll()
        {
            var Role =  _RolRepository.GetAll();
            var RolDto = _mapper.Map<IEnumerable<RolDto>>(Role);
            var response = new ApiResponse<IEnumerable<RolDto>>(RolDto);

            return Ok(response);
        }

        //Request to get Role by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var Role = await _RolRepository.GetById(id);
            var RolDto = _mapper.Map<RolDto>(Role);
            var response = new ApiResponse<RolDto>(RolDto);
            return Ok(response);
        }

        //Request to create Role

        [HttpPost]

        public async Task<IActionResult> Add(RolDto RolDto)
        {
            var role = _mapper.Map<Role>(RolDto);
            await _RolRepository.Add(role);

            RolDto = _mapper.Map<RolDto>(role);
            var response = new ApiResponse<RolDto>(RolDto);
            return Ok(response);
        }

        //Request to update rol
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, RolDto rolDto)
        {
            var rol = _mapper.Map<Role>(rolDto);
            rol.Id = id;

            var result = await _RolRepository.Update(rol);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
        //Request to remove rol by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
        

           var result = await _RolRepository.Delete(id);
           var response = new ApiResponse<bool>(result);

           return Ok(response);
        
        }

    } 
}

