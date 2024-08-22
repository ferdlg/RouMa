
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

    public class UserController : ControllerBase
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UserController(IUserRepository UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }
        //Request to get all Users

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
           var Users = await _UserRepository.GetUsers();
           var UsersDto = _mapper.Map<IEnumerable<UserDto>>(Users);
            return Ok(UsersDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetUsers(int id)
        {
           var User = await _UserRepository.GetUser(id);
           var UserDto = _mapper.Map<UserDto>(User);
            return Ok(User);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(UserDto topDto)
        {
           var User = _mapper.Map<User>(topDto);
            await _UserRepository.PostUser(User);
            return Ok(User);
        }


        //Request to update User
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateUser(int id, UserDto UserDto)
        {
            var User = _mapper.Map<User>(UserDto);
            User.Id= id;

            await _UserRepository.UpdateUser(User);
            return Ok(User);
        }
        //Request to remove User by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteUser(int id)
        {
            {

                var result = await _UserRepository.DeleteUser(id);
                return Ok(result);
            }
        }
    }
}

