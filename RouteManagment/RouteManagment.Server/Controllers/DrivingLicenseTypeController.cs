
using AutoMapper;
using AutoMapper.Configuration.Annotations;
using ManejoRutas.Core.Interfaces;
using ManejoRutas.Infrastructure.Repositories;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Responses;
using System;



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
            var response = new ApiResponse<IEnumerable<DrivingLicenseTypeDto>>(DrivingLicenseTypeDto);
            return Ok(DrivingLicenseTypeDto);
        }
        //Request to get DrivingLicenseType by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var DrivingLicenseType = await _DrivingLicenseTypeRepository.GetById(id);
            var drivingLicenseDto = _mapper.Map<DrivingLicenseTypeDto>(DrivingLicenseType);
            var response = new ApiResponse<DrivingLicenseTypeDto>(drivingLicenseDto);

            return Ok(response);
        }

        //Request to create DrivingLicenseType

        [HttpPost]

        public async Task<IActionResult> Add(DrivingLicenseTypeDto drivingLicenseTypeDto)
        {
            var drivingLicenseType = _mapper.Map<DrivingLicenseType>(drivingLicenseTypeDto);
            await _DrivingLicenseTypeRepository.Add(drivingLicenseType);

            drivingLicenseTypeDto = _mapper.Map<DrivingLicenseTypeDto>(drivingLicenseType);
            var response = new ApiResponse<DrivingLicenseTypeDto>(drivingLicenseTypeDto);
            return Ok(response);
        }
            //Request to update DrivingLicenseType
            [HttpPut("{id}")]

            public async Task<IActionResult> Update(int id, DrivingLicenseTypeDto DrivingLicenseTypeDto)
            {
                var DrivingLicenseType = _mapper.Map<DrivingLicenseType>(DrivingLicenseTypeDto);
                DrivingLicenseType.Id = id;

                var result = await _DrivingLicenseTypeRepository.Update(DrivingLicenseType);
                var response = new ApiResponse<bool>(result);
                return Ok(response);
            }
            //Request to remove DrivingLicenseType by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(int id)
            {
            

               var result = await _DrivingLicenseTypeRepository.Delete(id);
               var response = new ApiResponse<bool>(result);
               return Ok(response);
            
            }
    } 
}

