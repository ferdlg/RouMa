
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;


namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class StreetTypeController : ControllerBase
    {
        private readonly IStreetTypeRepository _streetTypeRepository;
        private readonly IMapper _mapper;

        public StreetTypeController(IStreetTypeRepository StreetTypeRepository, IMapper mapper)
        {
            _streetTypeRepository = StreetTypeRepository;
            _mapper = mapper;
        }
        //Request to get all StreetTypes

        [HttpGet]
        public async Task<IActionResult> GetStreetTypes()
        {
           var streetTypes = await _streetTypeRepository.GetStreetTypes();
           var streetTypesDto = _mapper.Map<IEnumerable<StreetTypeDto>>(streetTypes);
            return Ok(streetTypesDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetStreetTypes(int id)
        {
           var streetType = await _streetTypeRepository.GetStreetType(id);
           var streetTypeDto = _mapper.Map<StreetTypeDto>(streetType);
            return Ok(streetType);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(StreetTypeDto topDto)
        {
           var streetType = _mapper.Map<StreetType>(topDto);
            await _streetTypeRepository.PostStreetType(streetType);
            return Ok(streetType);
        }

        //Request to update top
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttop(int id)
        {
           var streetType = await _streetTypeRepository.PutStreetType(id);
           var streetTypeDto = _mapper.Map<StreetTypeDto>(streetType);
            return Ok(streetTypeDto);
        }

        //Request to remove top 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetop(int id)
        {
           var streetType = await _streetTypeRepository.DeleteStreetType(id);
           var streetTypeDto = _mapper.Map<StreetTypeDto>(streetType);

            return Ok(streetTypeDto);
        }
    }
}

