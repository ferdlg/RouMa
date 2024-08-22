
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

    public class TransportRequestController : ControllerBase
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public TransportRequestController(ITransportRequestRepository TransportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = TransportRequestRepository;
            _mapper = mapper;
        }
        //Request to get all TransportRequests

        [HttpGet]
        public async Task<IActionResult> GetTransportRequests()
        {
           var TransportRequests = await _transportRequestRepository.GetTransportRequests();
           var TransportRequestsDto = _mapper.Map<IEnumerable<TransportRequestDto>>(TransportRequests);
            return Ok(TransportRequestsDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetTransportRequests(int id)
        {
           var TransportRequest = await _transportRequestRepository.GetTransportRequest(id);
           var TransportRequestDto = _mapper.Map<TransportRequestDto>(TransportRequest);
            return Ok(TransportRequest);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(TransportRequestDto topDto)
        {
           var TransportRequest = _mapper.Map<TransportRequest>(topDto);
            await _transportRequestRepository.PostTransportRequest(TransportRequest);
            return Ok(TransportRequest);
        }


        //Request to update transportRequest
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatetransportRequest(int id, TransportRequestDto transportRequestDto)
        {
            var transportRequest = _mapper.Map<TransportRequest>(transportRequestDto);
            transportRequest.Id = id;

            await _transportRequestRepository.UpdateTransportRequest(transportRequest);
            return Ok(transportRequest);
        }
        //Request to remove transportRequest by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteTransportRequest(int id)
        {
            {

                var result = await _transportRequestRepository.DeleteTransportRequest(id);
                return Ok(result);
            }
        }
    }
}

