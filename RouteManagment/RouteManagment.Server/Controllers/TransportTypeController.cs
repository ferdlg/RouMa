
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

    public class TransportTypeController : ControllerBase
    {
        private readonly IRepository<TransportType> _TransportTypeRepository;
        private readonly IMapper _mapper;

        public TransportTypeController(IRepository<TransportType>  TransportTypeRepository, IMapper mapper)
        {
            _TransportTypeRepository = TransportTypeRepository;
            _mapper = mapper;
        }
        //Request to get all TransportTypes

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var TransportTypes = await _TransportTypeRepository.GetAll();
           var TransportTypesDto = _mapper.Map<IEnumerable<TransportTypeDto>>(TransportTypes);
            return Ok(TransportTypesDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var TransportType = await _TransportTypeRepository.GetById(id);
           var TransportTypeDto = _mapper.Map<TransportTypeDto>(TransportType);
            return Ok(TransportType);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(TransportTypeDto topDto)
        {
           var TransportType = _mapper.Map<TransportType>(topDto);
            await _TransportTypeRepository.Add(TransportType);
            return Ok(TransportType);
        }


        //Request to update transportType
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, TransportTypeDto transportTypeDto)
        {
            var transportType = _mapper.Map<TransportType>(transportTypeDto);
            transportType.Id = id;

            await _TransportTypeRepository.Update(transportType);
            return Ok(transportType);
        }
        //Request to remove transportType by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _TransportTypeRepository.Delete(id);
                return Ok();
            }
        }
    }
}

