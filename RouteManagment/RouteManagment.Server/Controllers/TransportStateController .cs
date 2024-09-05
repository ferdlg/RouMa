
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

    public class TransportStateController : ControllerBase
    {
        private readonly IService<TransportState> _TransportStateRepository;
        private readonly IMapper _mapper;

        public TransportStateController(IService<TransportState> TransportStateRepository, IMapper mapper)
        {
            _TransportStateRepository = TransportStateRepository;
            _mapper = mapper;
        }
        //Request to get all TransportStates

        [HttpGet]
        public IActionResult GetAll()
        {
           var TransportStates = _TransportStateRepository.GetAll();
           var TransportStatesDto = _mapper.Map<IEnumerable<TransportStateDto>>(TransportStates);
           var response = new ApiResponse<IEnumerable<TransportStateDto>>(TransportStatesDto);
           return Ok(response);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var TransportState = await _TransportStateRepository.GetById(id);
           var TransportStateDto = _mapper.Map<TransportStateDto>(TransportState);
           var response = new ApiResponse<TransportStateDto>(TransportStateDto);
           return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(TransportStateDto transportDto)
        {
            var TransportState = _mapper.Map<TransportState>(transportDto);
            await _TransportStateRepository.Add(TransportState);

            transportDto = _mapper.Map<TransportStateDto>(TransportState);
            var response = new ApiResponse<TransportStateDto>(transportDto);
            return Ok(response);

        }

        //Request to update transportState
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, TransportStateDto transportStateDto)
        {
            var transportState = _mapper.Map<TransportState>(transportStateDto);
            transportState.Id= id;

            var result=  await _TransportStateRepository.Update(transportState);
            var response = new ApiResponse<TransportState>(result);

            return Ok(response);
        }
        //Request to remove transportState by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
           var result = await _TransportStateRepository.Delete(id);
           var response = new ApiResponse<TransportState>(result);
           return Ok(response);
        }
    }
}

