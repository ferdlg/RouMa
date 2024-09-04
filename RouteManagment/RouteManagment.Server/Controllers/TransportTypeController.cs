
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

    public class TransportTypeController : ControllerBase
    {
        private readonly IRepository<TransportType> _TransportTypeRepository;
        private readonly IMapper _mapper;

        public TransportTypeController(IRepository<TransportType>  TransportTypeRepository, IMapper mapper)
        {
            _TransportTypeRepository = TransportTypeRepository;
            _mapper = mapper;
        }
        //Request to get all TransportTypes

        [HttpGet]
        public IActionResult GetAll()
        {
           var TransportTypes = _TransportTypeRepository.GetAll();
           var TransportTypesDto = _mapper.Map<IEnumerable<TransportTypeDto>>(TransportTypes);
           var response = new ApiResponse<IEnumerable<TransportTypeDto>>(TransportTypesDto);
           return Ok(response);
        }
        //Request to get top by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
           var TransportType = await _TransportTypeRepository.GetById(id);
           var TransportTypeDto = _mapper.Map<TransportTypeDto>(TransportType);
           var response = new ApiResponse<TransportTypeDto>(TransportTypeDto);
           return Ok(response);
        }

        //Request to create top

        [HttpPost]

        public async Task<IActionResult> Add(TransportTypeDto topDto)
        {
           var TransportType = _mapper.Map<TransportType>(topDto);
           await _TransportTypeRepository.Add(TransportType);
           return Ok(TransportType);
        }


        //Request to update transportType
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, TransportTypeDto transportTypeDto)
        {
            var transportType = _mapper.Map<TransportType>(transportTypeDto);
            transportType.Id = id;

            var result = await _TransportTypeRepository.Update(transportType);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        //Request to remove transportType by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
         

            var result = await _TransportTypeRepository.Delete(id);
            var response = new ApiResponse<bool>(result);

            return Ok(response);
         
        }
    }
}

