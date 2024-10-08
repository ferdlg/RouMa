
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

    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;
        private readonly IMapper _mapper;

        public UserController(IUserService UserService, IMapper mapper)
        {
            _UserService = UserService;
            _mapper = mapper;
        }
        //Request to get all Users

        [HttpGet]
        public IActionResult GetAll()
        {
           var Users =  _UserService.GetUsers();
           var UsersDto = _mapper.Map<IEnumerable<UserDto>>(Users);
           var response = new ApiResponse<IEnumerable<UserDto>>(UsersDto);
            return Ok(response);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var User = await _UserService.GetUserById(id);
           var UserDto = _mapper.Map<UserDto>(User);
           var response = new ApiResponse<UserDto>(UserDto);
           return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(UserDto userDto)
        {
           var user = _mapper.Map<User>(userDto);
           await _UserService.InsertUser(user);

           userDto = _mapper.Map<UserDto>(user);
           var response = new ApiResponse<UserDto>(userDto);
            return Ok(response);
        }


        //Request to update User
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, UserDto UserDto)
        {
            var User = _mapper.Map<User>(UserDto);
            User.Id= id;

            var result = await _UserService.Update(User);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
        }
        //Request to remove User by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           var result = await _UserService.Delete(id);
           var response = new ApiResponse<bool>(result);
           return Ok(response);
        
        }
    }
}

