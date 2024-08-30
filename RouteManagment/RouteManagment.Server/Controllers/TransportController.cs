
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Responses;


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
           var response = new ApiResponse<IEnumerable<TransportDto>>(transportsDto);
           return Ok(response);
        }
        //Request to get top by id

        [HttpGet("{plate}")]

        public async Task<IActionResult> GetTransports(string? plate)
        {
           var transport = await _transportRepository.GetTransport(plate);
           var transportDto = _mapper.Map<TransportDto>(transport);
           var response = new ApiResponse<TransportDto>(transportDto);

           return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(TransportDto transportDto)
        {
           var transport = _mapper.Map<Transport>(transportDto);
           await _transportRepository.PostTransport(transport);

           transportDto = _mapper.Map<TransportDto>(_transportRepository);
           var response = new ApiResponse<TransportDto>(transportDto);
           return Ok(response);
        }


        //Request to update transport
        [HttpPut("{plate}")]

        public async Task<IActionResult> UpdateTransport(string? plate, TransportDto transportDto)
        {
            var transport = _mapper.Map<Transport>(transportDto);
            transport.Plate = plate;

            var result= await _transportRepository.UpdateTransport(transport);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        //Request to remove transport by id 
        [HttpDelete("{plate}")]

        public async Task<IActionResult> Deletetransport(string? plate)
        {
           var result = await _transportRepository.DeleteTransport(plate);
           var response = new ApiResponse<bool>(result);
           return Ok(response);
        
        }
    }
}

