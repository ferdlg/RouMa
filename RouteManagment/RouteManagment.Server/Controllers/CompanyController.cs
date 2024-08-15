
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

    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        //Request to get all companies

        [HttpGet]
        public async Task<IActionResult> GetCompanies()
        {
            var companies = await _companyRepository.GetCompanies();
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companiesDto);
        }
        //Request to get company by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetCompanies(int id)
        {
            var company = await _companyRepository.GetCompany(id);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(company);
        }

        //Request to create company

        [HttpPost]

        public async Task<IActionResult> PostCompany(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            await _companyRepository.PostCompany(company);
            return Ok(company);
        }

        //Request to update company
        [HttpPut("{id}")]

        public async Task<IActionResult> Updatecompany(int id, CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            company.CompanyId = id;

            await _companyRepository.UpdateCompany(company);
            return Ok(company);
        }
        //Request to remove company by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Deletecompany(int id)
        {
            {

                var result = await _companyRepository.Deletecompany(id);
                return Ok(result);
            }
        }

    } 
}

