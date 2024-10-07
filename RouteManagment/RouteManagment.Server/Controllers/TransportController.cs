
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Core.Services;
using RouteManagment.Server.Responses;


namespace RouteManagment.Server.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    //Request Managment

    public class TransportController : ControllerBase
    {
        private readonly ITransportService _transportService;
        private readonly IMapper _mapper;

        public TransportController(ITransportService transportService, IMapper mapper)
        {
            _transportService = transportService;
            _mapper = mapper;
        }
        //Request to get all Transports

        [HttpGet]
        public IActionResult GetTransports()
        {
           var transports = _transportService.GetTransports();
           var transportsDto = _mapper.Map<IEnumerable<TransportDto>>(transports);
           var response = new ApiResponse<IEnumerable<TransportDto>>(transportsDto);
           return Ok(response);
        }
        //Request to get top by id

        [HttpGet("{plate}")]

        public async Task<IActionResult> GetTransports(string plate)
        {
           var transport = await _transportService.GetTransport(plate);
           var transportDto = _mapper.Map<TransportDto>(transport);
           var response = new ApiResponse<TransportDto>(transportDto);

           return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Posttop(TransportDto transportDto)
        {
           var transport = _mapper.Map<Transport>(transportDto);
           await _transportService.InsertTransport(transport);

           transportDto = _mapper.Map<TransportDto>(_transportService);
           var response = new ApiResponse<TransportDto>(transportDto);
           return Ok(response);
        }


        //Request to update transport
        [HttpPut("{plate}")]

        public async Task<IActionResult> Update(string plate, TransportDto transportDto)
        {
            var transport = _mapper.Map<Transport>(transportDto);
            transport.Plate = plate;

            var result= await _transportService.Update(transport);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        //Request to remove transport by id 
        [HttpDelete("{plate}")]

        public async Task<IActionResult> Delete(string plate)
        {
            var result = await _transportService.Delete(plate);
            var response = new ApiResponse<bool>(result);
            return Ok(response);

        }
    }
}

