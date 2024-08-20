
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

    public class TransportRequestStateController : ControllerBase
    {
        private readonly ITransportRequestStateRepository _TransportRequestStateRepository;
        private readonly IMapper _mapper;

        public TransportRequestStateController(ITransportRequestStateRepository TransportRequestStateRepository, IMapper mapper)
        {
            _TransportRequestStateRepository = TransportRequestStateRepository;
            _mapper = mapper;
        }
        //Request to get all TransportRequestStates

        [HttpGet]
        public async Task<IActionResult> GetTransportRequestStates()
        {
           var TransportRequestStates = await _TransportRequestStateRepository.GetTransportRequestStates();
           var TransportRequestStatesDto = _mapper.Map<IEnumerable<TransportRequestStateDto>>(TransportRequestStates);
            return Ok(TransportRequestStatesDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetTransportRequestStates(int id)
        {
           var TransportRequestState = await _TransportRequestStateRepository.GetTransportRequestState(id);
           var TransportRequestStateDto = _mapper.Map<TransportRequestStateDto>(TransportRequestState);
            return Ok(TransportRequestState);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(TransportRequestStateDto topDto)
        {
           var TransportRequestState = _mapper.Map<TransportRequestState>(topDto);
            await _TransportRequestStateRepository.PostTransportRequestState(TransportRequestState);
            return Ok(TransportRequestState);
        }


        //Request to update TransportRequestState
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateTransportRequestState(int id, TransportRequestStateDto TransportRequestStateDto)
        {
            var TransportRequestState = _mapper.Map<TransportRequestState>(TransportRequestStateDto);
            TransportRequestState.StateId= id;

            await _TransportRequestStateRepository.UpdateTransportRequestState(TransportRequestState);
            return Ok(TransportRequestState);
        }
        //Request to remove TransportRequestState by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTransportRequestState(int id)
        {
            {

                var result = await _TransportRequestStateRepository.DeleteTransportRequestState(id);
                return Ok(result);
            }
        }
    }
}

