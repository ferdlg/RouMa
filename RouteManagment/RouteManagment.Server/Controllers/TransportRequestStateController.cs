
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
        public async Task<IActionResult> GetAll()
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
            return Ok(TransportRequestStateDto);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(TransportRequestStateDto topDto)
        {
            var TransportRequestState = _mapper.Map<TransportRequestState>(topDto);
            await _TransportRequestStateRepository.Add(TransportRequestState);
            return Ok(TransportRequestState);
        }


        //Request to update TransportRequestState
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, TransportRequestStateDto TransportRequestStateDto)
        {
            var TransportRequestState = _mapper.Map<TransportRequestState>(TransportRequestStateDto);
            TransportRequestState.Id= id;

            await _TransportRequestStateRepository.Update(TransportRequestState);
            return Ok(TransportRequestState);
        }
        //Request to remove TransportRequestState by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _TransportRequestStateRepository.Delete(id);
                return Ok();
            }
        }
    }
}

