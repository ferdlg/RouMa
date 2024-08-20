
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

    public class DrivingLicenseTypeController : ControllerBase
    {
        private readonly IDrivingLicenseTypeRepository _DrivingLicenseTypeRepository;
        private readonly IMapper _mapper;

        public DrivingLicenseTypeController(IDrivingLicenseTypeRepository DrivingLicenseTypeRepository, IMapper mapper)
        {
            _DrivingLicenseTypeRepository = DrivingLicenseTypeRepository;
            _mapper = mapper;
        }
        //Request to get all DrivingLicenseTypes

        [HttpGet]
        public async Task<IActionResult> GetDrivingLicenseTypes()
        {
            var DrivingLicenseType = await _DrivingLicenseTypeRepository.GetDrivingLicenseTypes();
            var DrivingLicenseTypeDto = _mapper.Map<IEnumerable<DrivingLicenseTypeDto>>(DrivingLicenseType);
            return Ok(DrivingLicenseTypeDto);
        }
        //Request to get DrivingLicenseType by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetDrivingLicenseType(int id)
        {
            var DrivingLicenseType = await _DrivingLicenseTypeRepository.GetDrivingLicenseType(id);
            var documenTypeDto = _mapper.Map<DrivingLicenseTypeDto>(DrivingLicenseType);
            return Ok(DrivingLicenseType);
        }

        //Request to create DrivingLicenseType

        [HttpPost]

        public async Task<IActionResult> PostDrivingLicenseType(DrivingLicenseTypeDto DrivingLicenseTypeDto)
        {
            var DrivingLicenseType = _mapper.Map<DrivingLicenseType>(DrivingLicenseTypeDto);
            await _DrivingLicenseTypeRepository.PostDrivingLicenseType(DrivingLicenseType);
            return Ok(DrivingLicenseType);
        }
            //Request to update DrivingLicenseType
            [HttpPut("{id}")]

            public async Task<IActionResult> UpdateDrivingLicenseType(int id, DrivingLicenseTypeDto DrivingLicenseTypeDto)
            {
                var DrivingLicenseType = _mapper.Map<DrivingLicenseType>(DrivingLicenseTypeDto);
                DrivingLicenseType.TypeLicenseId = id;

                await _DrivingLicenseTypeRepository.UpdateDrivingLicenseType(DrivingLicenseType);
                return Ok(DrivingLicenseType);
            }
            //Request to remove DrivingLicenseType by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> DeleteDrivingLicenseType(int id)
            {
                {

                    var result = await _DrivingLicenseTypeRepository.DeleteDrivingLicenseType(id);
                    return Ok(result);
                }
            }
    } 
}

