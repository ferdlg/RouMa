
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

    public class TransportRequestController : ControllerBase
    {
        private readonly IService<TransportRequest> _transportRequestRepository;
        private readonly IMapper _mapper;

        public TransportRequestController(IService<TransportRequest> TransportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = TransportRequestRepository;
            _mapper = mapper;
        }
        //Request to get all TransportRequests

        [HttpGet]
        public IActionResult GetAll()
        {
           var TransportRequests =  _transportRequestRepository.GetAll();
           var TransportRequestsDto = _mapper.Map<IEnumerable<TransportRequestDto>>(TransportRequests);
            return Ok(TransportRequestsDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var TransportRequest = await _transportRequestRepository.GetById(id);
           var TransportRequestDto = _mapper.Map<TransportRequestDto>(TransportRequest);
           var response = new ApiResponse<TransportRequestDto>(TransportRequestDto);
           return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(TransportRequestDto transportDto)
        {
           var TransportRequest = _mapper.Map<TransportRequest>(transportDto);
           await _transportRequestRepository.Add(TransportRequest);

           transportDto = _mapper.Map<TransportRequestDto>(TransportRequest);
           var response = new ApiResponse<TransportRequestDto>(transportDto);
           return Ok(response);
        }


        //Request to update transportRequest
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, TransportRequestDto transportRequestDto)
        {
            var transportRequest = _mapper.Map<TransportRequest>(transportRequestDto);
            transportRequest.Id = id;

            var result= await _transportRequestRepository.Update(transportRequest);
            var response = new ApiResponse<TransportRequest>(result);
            return Ok(response);
        }
        //Request to remove transportRequest by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
          var result = await _transportRequestRepository.Delete(id);
          var response = new ApiResponse<TransportRequest>(result);
          return Ok(response);
        }
    }
}

