
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;


namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class UserController : ControllerBase
    {
        private readonly IRepository<User> _UserRepository;
        private readonly IMapper _mapper;

        public UserController(IRepository<User> UserRepository, IMapper mapper)
        {
            _UserRepository = UserRepository;
            _mapper = mapper;
        }
        //Request to get all Users

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var Users = await _UserRepository.GetAll();
           var UsersDto = _mapper.Map<IEnumerable<UserDto>>(Users);
            return Ok(UsersDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var User = await _UserRepository.GetById(id);
           var UserDto = _mapper.Map<UserDto>(User);
            return Ok(User);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(UserDto topDto)
        {
           var User = _mapper.Map<User>(topDto);
            await _UserRepository.Add(User);
            return Ok(User);
        }


        //Request to update User
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, UserDto UserDto)
        {
            var User = _mapper.Map<User>(UserDto);
            User.Id= id;

            await _UserRepository.Update(User);
            return Ok(User);
        }
        //Request to remove User by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _UserRepository.Delete(id);
                return Ok();
            }
        }
    }
}

