
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

    public class AdministratorController : ControllerBase
    {
        private readonly IService<Administrator> _administratorService;
        private readonly IMapper _mapper;

        public AdministratorController(IService<Administrator> administratorService, IMapper mapper)
        {
            _administratorService = administratorService;
            _mapper = mapper;
        }
        //Request to get all administrator

        [HttpGet]
        public IActionResult GetAll()
        {
            var administrators =  _administratorService.GetAll();
            var administratorsDto = _mapper.Map<IEnumerable<AdministratorDto>>(administrators);

            var response = new ApiResponse<IEnumerable<AdministratorDto>>(administratorsDto);
            return Ok(response);
        }

        //Request to get administrator by id 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var administrator = await _administratorService.GetById(id);
            var administratorDto = _mapper.Map<AdministratorDto>(administrator);
            var response = new ApiResponse<AdministratorDto>(administratorDto);
            return Ok(response);
        }

        //Request to create administrator
        [HttpPost]
        public async Task<IActionResult> Add(AdministratorDto administratorDto)
        {
            var administrator = _mapper.Map<Administrator>(administratorDto);
            await _administratorService.Add(administrator);

            administratorDto = _mapper.Map<AdministratorDto>(administrator);
            var response = new ApiResponse<AdministratorDto>(administratorDto);
            return Ok(response);
        }

        //Request to update administrator
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, AdministratorDto administratorDto)
        {
            var administrator = _mapper.Map<Administrator>(administratorDto);
            administrator.Id = id;

            var result = await _administratorService.Update(administrator);
            var response = new ApiResponse<Administrator>(result);
            return Ok(response);
        }
        //Request to remove administrator by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _administratorService.Delete(id);
            var response = new ApiResponse<Administrator>(result);
            return Ok(response);
            
        }

    }
}

