
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

    public class TransportStateController : ControllerBase
    {
        private readonly ITransportStateRepository _TransportStateRepository;
        private readonly IMapper _mapper;

        public TransportStateController(ITransportStateRepository TransportStateRepository, IMapper mapper)
        {
            _TransportStateRepository = TransportStateRepository;
            _mapper = mapper;
        }
        //Request to get all TransportStates

        [HttpGet]
        public async Task<IActionResult> GetTransportStates()
        {
           var TransportStates = await _TransportStateRepository.GetTransportStates();
           var TransportStatesDto = _mapper.Map<IEnumerable<TransportStateDto>>(TransportStates);
            return Ok(TransportStatesDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetTransportStates(int id)
        {
           var TransportState = await _TransportStateRepository.GetTransportState(id);
           var TransportStateDto = _mapper.Map<TransportStateDto>(TransportState);
            return Ok(TransportState);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(TransportStateDto topDto)
        {
           var TransportState = _mapper.Map<TransportState>(topDto);
            await _TransportStateRepository.PostTransportState(TransportState);
            return Ok(TransportState);
        }


        //Request to update transportState
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatetransportState(int id, TransportStateDto transportStateDto)
        {
            var transportState = _mapper.Map<TransportState>(transportStateDto);
            transportState.StateId= id;

            await _TransportStateRepository.UpdatetransportState(transportState);
            return Ok(transportState);
        }
        //Request to remove transportState by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletetransportState(int id)
        {
            {

                var result = await _TransportStateRepository.DeleteTransportState(id);
                return Ok(result);
            }
        }
    }
}

