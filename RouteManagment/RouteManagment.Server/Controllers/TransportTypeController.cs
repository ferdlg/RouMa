
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

    public class TransportTypeController : ControllerBase
    {
        private readonly ITransportTypeRepository _TransportTypeRepository;
        private readonly IMapper _mapper;

        public TransportTypeController(ITransportTypeRepository TransportTypeRepository, IMapper mapper)
        {
            _TransportTypeRepository = TransportTypeRepository;
            _mapper = mapper;
        }
        //Request to get all TransportTypes

        [HttpGet]
        public async Task<IActionResult> GetTransportTypes()
        {
           var TransportTypes = await _TransportTypeRepository.GetTransportTypes();
           var TransportTypesDto = _mapper.Map<IEnumerable<TransportTypeDto>>(TransportTypes);
            return Ok(TransportTypesDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetTransportTypes(int id)
        {
           var TransportType = await _TransportTypeRepository.GetTransportType(id);
           var TransportTypeDto = _mapper.Map<TransportTypeDto>(TransportType);
            return Ok(TransportType);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(TransportTypeDto topDto)
        {
           var TransportType = _mapper.Map<TransportType>(topDto);
            await _TransportTypeRepository.PostTransportType(TransportType);
            return Ok(TransportType);
        }


        //Request to update transportType
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatetransportType(int id, TransportTypeDto transportTypeDto)
        {
            var transportType = _mapper.Map<TransportType>(transportTypeDto);
            transportType.TransportTypeId = id;

            await _TransportTypeRepository.UpdateTransportType(transportType);
            return Ok(transportType);
        }
        //Request to remove transportType by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTransportType(int id)
        {
            {

                var result = await _TransportTypeRepository.DeleteTransportType(id);
                return Ok(result);
            }
        }
    }
}

