
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;


namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class TransportStatusController : ControllerBase
    {
        private readonly ITransportStatusRepository _TransportStatusRepository;
        private readonly IMapper _mapper;

        public TransportStatusController(ITransportStatusRepository TransportStatusRepository, IMapper mapper)
        {
            _TransportStatusRepository = TransportStatusRepository;
            _mapper = mapper;
        }
        //Request to get all TransportStatuss

        [HttpGet]
        public async Task<IActionResult> GetTransportStatuss()
        {
           var TransportStatuss = await _TransportStatusRepository.GetTransportStatuss();
           var TransportStatussDto = _mapper.Map<IEnumerable<TransportStatusDto>>(TransportStatuss);
            return Ok(TransportStatussDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetTransportStatuss(int id)
        {
           var TransportStatus = await _TransportStatusRepository.GetTransportStatus(id);
           var TransportStatusDto = _mapper.Map<TransportStatusDto>(TransportStatus);
            return Ok(TransportStatus);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(TransportStatusDto topDto)
        {
           var TransportStatus = _mapper.Map<TransportStatus>(topDto);
            await _TransportStatusRepository.PostTransportStatus(TransportStatus);
            return Ok(TransportStatus);
        }

        //Request to update top
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttop(int id)
        {
           var TransportStatus = await _TransportStatusRepository.PutTransportStatus(id);
           var TransportStatusDto = _mapper.Map<TransportStatusDto>(TransportStatus);
            return Ok(TransportStatusDto);
        }

        //Request to remove top 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetop(int id)
        {
           var TransportStatus = await _TransportStatusRepository.DeleteTransportStatus(id);
           var TransportStatusDto = _mapper.Map<TransportStatusDto>(TransportStatus);

            return Ok(TransportStatusDto);
        }
    }
}

