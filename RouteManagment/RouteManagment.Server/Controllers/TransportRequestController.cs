
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

    public class TransportRequestController : ControllerBase
    {
        private readonly IRepository<TransportRequest> _transportRequestRepository;
        private readonly IMapper _mapper;

        public TransportRequestController(IRepository<TransportRequest> TransportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = TransportRequestRepository;
            _mapper = mapper;
        }
        //Request to get all TransportRequests

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var TransportRequests = await _transportRequestRepository.GetAll();
           var TransportRequestsDto = _mapper.Map<IEnumerable<TransportRequestDto>>(TransportRequests);
            return Ok(TransportRequestsDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var TransportRequest = await _transportRequestRepository.GetById(id);
           var TransportRequestDto = _mapper.Map<TransportRequestDto>(TransportRequest);
            return Ok(TransportRequest);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(TransportRequestDto topDto)
        {
           var TransportRequest = _mapper.Map<TransportRequest>(topDto);
            await _transportRequestRepository.Add(TransportRequest);
            return Ok(TransportRequest);
        }


        //Request to update transportRequest
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, TransportRequestDto transportRequestDto)
        {
            var transportRequest = _mapper.Map<TransportRequest>(transportRequestDto);
            transportRequest.Id = id;

            await _transportRequestRepository.Update(transportRequest);
            return Ok(transportRequest);
        }
        //Request to remove transportRequest by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _transportRequestRepository.Delete(id);
                return Ok();
            }
        }
    }
}

