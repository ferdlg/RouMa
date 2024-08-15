
using AutoMapper;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
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


        //Request to update transportStatus
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdatetransportStatus(int id, TransportStatusDto transportStatusDto)
        {
            var transportStatus = _mapper.Map<TransportStatus>(transportStatusDto);
            transportStatus.StatusId= id;

            await _TransportStatusRepository.UpdatetransportStatus(transportStatus);
            return Ok(transportStatus);
        }
        //Request to remove transportStatus by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeletetransportStatus(int id)
        {
            {

                var result = await _TransportStatusRepository.DeleteTransportStatus(id);
                return Ok(result);
            }
        }
    }
}

