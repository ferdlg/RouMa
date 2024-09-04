
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

    public class TransportRequestStateController : ControllerBase
    {
        private readonly IRepository<TransportRequestState> _TransportRequestStateRepository;
        private readonly IMapper _mapper;

        public TransportRequestStateController(IRepository<TransportRequestState> TransportRequestStateRepository, IMapper mapper)
        {
            _TransportRequestStateRepository = TransportRequestStateRepository;
            _mapper = mapper;
        }
        //Request to get all TransportRequestStates

        [HttpGet]
        public IActionResult GetAll()
        {
           var TransportRequestStates = await _TransportRequestStateRepository.GetAll();
           var TransportRequestStatesDto = _mapper.Map<IEnumerable<TransportRequestStateDto>>(TransportRequestStates);
           return Ok(TransportRequestStatesDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var TransportRequestState = await _TransportRequestStateRepository.GetById(id);
           var TransportRequestStateDto = _mapper.Map<TransportRequestStateDto>(TransportRequestState);
           var response = new ApiResponse<TransportRequestStateDto>(TransportRequestStateDto);

           return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(TransportRequestStateDto transportDto)
        {
            var TransportRequestState = _mapper.Map<TransportRequestState>(transportDto);
            await _TransportRequestStateRepository.Add(TransportRequestState);

            transportDto = _mapper.Map<TransportRequestStateDto>(TransportRequestState);
            var response = new ApiResponse<TransportRequestStateDto>(transportDto);
            return Ok(response);
        }


        //Request to update TransportRequestState
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, TransportRequestStateDto TransportRequestStateDto)
        {
            var TransportRequestState = _mapper.Map<TransportRequestState>(TransportRequestStateDto);
            TransportRequestState.Id= id;

            var result = await _TransportRequestStateRepository.Update(TransportRequestState);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        //Request to remove TransportRequestState by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _TransportRequestStateRepository.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        
        }
    }
}

