
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
        public async Task<IActionResult> GetAll()
        {
            var companies = await _companyRepository.GetAll();
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return Ok(companiesDto);
        }
        //Request to get company by id

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyRepository.GetById(id);
            var companyDto = _mapper.Map<CompanyDto>(company);
            return Ok(company);
        }

        //Request to create company

        [HttpPost]

        public async Task<IActionResult> Add(CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            await _companyRepository.Add(company);
            return Ok(company);
        }

        //Request to update company
        [HttpPut("{id}")]

        public async Task<IActionResult> Update(int id, CompanyDto companyDto)
        {
            var company = _mapper.Map<Company>(companyDto);
            company.Id = id;

            await _companyRepository.Update(company);
            return Ok(company);
        }
        //Request to remove company by id 
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            {

                await _companyRepository.Delete(id);
                return Ok();
            }
        }

    } 
}

