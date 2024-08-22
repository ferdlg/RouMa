
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
            return Ok(streetTypesDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var streetType = await _streetTypeRepository.GetById(id);
           var streetTypeDto = _mapper.Map<StreetTypeDto>(streetType);
            return Ok(streetType);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(StreetTypeDto topDto)
        {
           var streetType = _mapper.Map<StreetType>(topDto);
            await _streetTypeRepository.Add(streetType);
            return Ok(streetType);
        }

        //Request to update streetType
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, StreetTypeDto streetTypeDto)
        {
            var streetType = _mapper.Map<StreetType>(streetTypeDto);
            streetType.Id = id;

            await _streetTypeRepository.Update(streetType);
            return Ok(streetType);
        }
        //Request to remove streetType by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _streetTypeRepository.Delete(id);
                return Ok();
            }
        }
    }
}

