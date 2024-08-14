
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

    public class TransportController : ControllerBase
    {
        private readonly ITransportRepository _transportRepository;
        private readonly IMapper _mapper;

        public TransportController(ITransportRepository transportRepository, IMapper mapper)
        {
            _transportRepository = transportRepository;
            _mapper = mapper;
        }
        //Request to get all Transports

        [HttpGet]
        public async Task<IActionResult> GetTransports()
        {
           var transports = await _transportRepository.GetTransports();
           var transportsDto = _mapper.Map<IEnumerable<TransportDto>>(transports);
            return Ok(transportsDto);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetTransports(int id)
        {
           var transport = await _transportRepository.GetTransport(id);
           var transportDto = _mapper.Map<TransportDto>(transport);
            return Ok(transport);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(TransportDto topDto)
        {
           var transport = _mapper.Map<Transport>(topDto);
            await _transportRepository.PostTransport(transport);
            return Ok(transport);
        }

        //Request to update top
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttop(int id)
        {
           var transport = await _transportRepository.PutTransport(id);
           var transportDto = _mapper.Map<TransportDto>(transport);
            return Ok(transportDto);
        }

        //Request to remove top 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletetop(int id)
        {
           var transport = await _transportRepository.DeleteTransport(id);
           var transportDto = _mapper.Map<TransportDto>(transport);

            return Ok(transportDto);
        }
    }
}

