
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
        private readonly IServiceP<DrivingLicenseType> _DrivingLicenseTypeService;
        private readonly IMapper _mapper;

        public DrivingLicenseTypeController(IServiceP<DrivingLicenseType> DrivingLicenseTypeService, IMapper mapper)
        {
            _DrivingLicenseTypeService = DrivingLicenseTypeService;
            _mapper = mapper;
        }
        //Request to get all DrivingLicenseTypes

        [HttpGet]
        public IActionResult GetAll()
        {
            var DrivingLicenseType =  _DrivingLicenseTypeService.GetAll();
            var DrivingLicenseTypeDto = _mapper.Map<IEnumerable<DrivingLicenseTypeDto>>(DrivingLicenseType);
            var response = new ApiResponse<IEnumerable<DrivingLicenseTypeDto>>(DrivingLicenseTypeDto);
            return Ok(DrivingLicenseTypeDto);
        }
        //Request to get DrivingLicenseType by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var DrivingLicenseType = await _DrivingLicenseTypeService.GetById(id);
            var drivingLicenseDto = _mapper.Map<DrivingLicenseTypeDto>(DrivingLicenseType);
            var response = new ApiResponse<DrivingLicenseTypeDto>(drivingLicenseDto);

            return Ok(response);
        }

        //Request to create DrivingLicenseType

        [HttpPost]

        public async Task<IActionResult> Add(DrivingLicenseTypeDto drivingLicenseTypeDto)
        {
            var drivingLicenseType = _mapper.Map<DrivingLicenseType>(drivingLicenseTypeDto);
            await _DrivingLicenseTypeService.Add(drivingLicenseType);

            drivingLicenseTypeDto = _mapper.Map<DrivingLicenseTypeDto>(drivingLicenseType);
            var response = new ApiResponse<DrivingLicenseTypeDto>(drivingLicenseTypeDto);
            return Ok(response);
        }
            //Request to update DrivingLicenseType
            [HttpPut("{id}")]

            public async Task<IActionResult> Update(int id, DrivingLicenseTypeDto DrivingLicenseTypeDto)
            {
                    var driving = _mapper.Map<DrivingLicenseType>(DrivingLicenseTypeDto);
                    driving.Id = id;

                    var result = await _DrivingLicenseTypeService.Update(driving);
                    var response = new ApiResponse<DrivingLicenseType>(result);
                    return Ok(response);

            }
            //Request to remove DrivingLicenseType by id 
            [HttpDelete("{id}")]

            public async Task<IActionResult> Delete(int id)
            {

                var result = await _DrivingLicenseTypeService.Delete(id);
                var response = new ApiResponse<DrivingLicenseType>(result);
                return Ok(response);
        }
    } 
}

