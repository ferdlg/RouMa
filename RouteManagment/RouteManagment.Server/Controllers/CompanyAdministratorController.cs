
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

    public class CompanyAdministratorController : ControllerBase
    {
        private readonly IServiceP<CompanyAdministrator> _companyService;
        private readonly IMapper _mapper;

        public CompanyAdministratorController(IServiceP<CompanyAdministrator> companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        //Request to get all companies

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies =  _companyService.GetAll();
            var companiesDto = _mapper.Map<IEnumerable<CompanyAdminDto>>(companies);
            var response = new ApiResponse<IEnumerable<CompanyAdminDto>>(companiesDto);

            return Ok(response);
        }
        //Request to get company by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetById(id);
            var CompanyAdminDto = _mapper.Map<CompanyAdminDto>(company);
            var response = new ApiResponse<CompanyAdminDto>(CompanyAdminDto);
            return Ok(response);
        }

        //Request to create company

        [HttpPost]

        public async Task<IActionResult> Add(CompanyAdminDto CompanyAdminDto)
        {
            var company = _mapper.Map<CompanyAdministrator>(CompanyAdminDto);
            await _companyService.Add(company);

            CompanyAdminDto = _mapper.Map<CompanyAdminDto>(company);
            var response = new ApiResponse<CompanyAdminDto>(CompanyAdminDto);
            return Ok(response);
        }

        //Request to update company
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, CompanyAdminDto CompanyAdminDto)
        {
            var company = _mapper.Map<CompanyAdministrator>(CompanyAdminDto);
            company.Id = id;

            var result = await _companyService.Update(company);
            var response = new ApiResponse<CompanyAdministrator>(result);
            return Ok(response);
        }
        //Request to remove company by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
    
            var result = await _companyService.Delete(id);
            var response = new ApiResponse<CompanyAdministrator>(result);
            return Ok(response);
        }

    } 
}

