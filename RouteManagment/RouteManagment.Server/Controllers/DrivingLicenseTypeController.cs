
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

    public class DrivingLicenseTypeController : ControllerBase
    {
        private readonly IRepository<DrivingLicenseType> _DrivingLicenseTypeRepository;
        private readonly IMapper _mapper;

        public DrivingLicenseTypeController(IRepository<DrivingLicenseType> DrivingLicenseTypeRepository, IMapper mapper)
        {
            _DrivingLicenseTypeRepository = DrivingLicenseTypeRepository;
            _mapper = mapper;
        }
        //Request to get all DrivingLicenseTypes

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var DrivingLicenseType = await _DrivingLicenseTypeRepository.GetAll();
            var DrivingLicenseTypeDto = _mapper.Map<IEnumerable<DrivingLicenseTypeDto>>(DrivingLicenseType);
            return Ok(DrivingLicenseTypeDto);
        }
        //Request to get DrivingLicenseType by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var DrivingLicenseType = await _DrivingLicenseTypeRepository.GetById(id);
            var documenTypeDto = _mapper.Map<DrivingLicenseTypeDto>(DrivingLicenseType);
            return Ok(DrivingLicenseType);
        }

        //Request to create DrivingLicenseType

        [HttpPost]

        public async Task<IActionResult> Add(DrivingLicenseTypeDto DrivingLicenseTypeDto)
        {
            var DrivingLicenseType = _mapper.Map<DrivingLicenseType>(DrivingLicenseTypeDto);
            await _DrivingLicenseTypeRepository.Add(DrivingLicenseType);
            return Ok(DrivingLicenseType);
        }
            //Request to update DrivingLicenseType
            [HttpPut("{id}")]

            public async Task<IActionResult> Update(int id, DrivingLicenseTypeDto DrivingLicenseTypeDto)
            {
                var DrivingLicenseType = _mapper.Map<DrivingLicenseType>(DrivingLicenseTypeDto);
                DrivingLicenseType.Id = id;

                await _DrivingLicenseTypeRepository.Update(DrivingLicenseType);
                return Ok(DrivingLicenseType);
            }
            //Request to remove DrivingLicenseType by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(int id)
            {
                {

                    await _DrivingLicenseTypeRepository.Delete(id);
                    return Ok();
                }
            }
    } 
}

