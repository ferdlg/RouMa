
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

    public class StreetTypeController : ControllerBase
    {
        private readonly IRepository<StreetType> _streetTypeRepository;
        private readonly IMapper _mapper;

        public StreetTypeController(IRepository<StreetType> StreetTypeRepository, IMapper mapper)
        {
            _streetTypeRepository = StreetTypeRepository;
            _mapper = mapper;
        }
        //Request to get all StreetTypes

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var streetTypes = await _streetTypeRepository.GetAll();
           var streetTypesDto = _mapper.Map<IEnumerable<StreetTypeDto>>(streetTypes);
           var response = new ApiResponse<IEnumerable<StreetTypeDto>>(streetTypesDto);
           return Ok(response);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var streetType = await _streetTypeRepository.GetById(id);
           var streetTypeDto = _mapper.Map<StreetTypeDto>(streetType);
           var response = new ApiResponse<StreetTypeDto>(streetTypeDto);
           return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(StreetTypeDto streetDto)
        {
           var streetType = _mapper.Map<StreetType>(streetDto);
           await _streetTypeRepository.Add(streetType);

           streetDto = _mapper.Map<StreetTypeDto>(streetType);
           var response = new ApiResponse<StreetTypeDto>(streetDto);
           return Ok(response); 
        }

        //Request to update streetType
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, StreetTypeDto streetTypeDto)
        {
            var streetType = _mapper.Map<StreetType>(streetTypeDto);
            streetType.Id = id;

            var result=await _streetTypeRepository.Update(streetType);
            var response = new ApiResponse<bool>(result);
            return Ok(streetType);
        }
        //Request to remove streetType by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           var result = await _streetTypeRepository.Delete(id);
           var response = new ApiResponse<bool>(result);
           return Ok();
        
        }
    }
}

