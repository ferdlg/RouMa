
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

    public class CompanyController : ControllerBase
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(IRepository<Company> companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        //Request to get all companies

        [HttpGet]
        public IActionResult GetAll()
        {
            var companies =  _companyRepository.GetAll();
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            var response = new ApiResponse<IEnumerable<CompanyDto>>(companiesDto);

            return Ok(response);
        }
        //Request to get company by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyRepository.GetById(id);
            var companyDto = _mapper.Map<CompanyDto>(company);
            var response = new ApiResponse<CompanyDto>(companyDto);
            return Ok(response);
        }

        //Request to create company

        [HttpPost]

        public async Task<IActionResult> Add(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            await _companyRepository.Add(company);

            companyDto = _mapper.Map<CompanyDto>(company);
            var response = new ApiResponse<CompanyDto>(companyDto);
            return Ok(response);
        }

        //Request to update company
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            company.Id = id;

            var result = await _companyRepository.Update(company);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
        //Request to remove company by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
    
            var result = await _companyRepository.Delete(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    } 
}

