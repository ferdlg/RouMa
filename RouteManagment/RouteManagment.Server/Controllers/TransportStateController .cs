
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

    public class TransportStateController : ControllerBase
    {
        private readonly IRepository<TransportState> _TransportStateRepository;
        private readonly IMapper _mapper;

        public TransportStateController(IRepository<TransportState> TransportStateRepository, IMapper mapper)
        {
            _TransportStateRepository = TransportStateRepository;
            _mapper = mapper;
        }
        //Request to get all TransportStates

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
           var TransportStates = await _TransportStateRepository.GetAll();
           var TransportStatesDto = _mapper.Map<IEnumerable<TransportStateDto>>(TransportStates);
            return Ok(TransportStatesDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var TransportState = await _TransportStateRepository.GetById(id);
           var TransportStateDto = _mapper.Map<TransportStateDto>(TransportState);
            return Ok(TransportState);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(TransportStateDto topDto)
        {
            var TransportState = _mapper.Map<TransportState>(topDto);
            await _TransportStateRepository.Add(TransportState);
            return Ok(TransportState);
        }


        //Request to update transportState
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, TransportStateDto transportStateDto)
        {
            var transportState = _mapper.Map<TransportState>(transportStateDto);
            transportState.Id= id;

            await _TransportStateRepository.Update(transportState);
            return Ok(transportState);
        }
        //Request to remove transportState by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _TransportStateRepository.Delete(id);
                return Ok();
            }
        }
    }
}

