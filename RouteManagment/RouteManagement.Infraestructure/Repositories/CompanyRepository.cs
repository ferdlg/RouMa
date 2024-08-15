using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public CompanyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all companies
        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = await _appDbContext.Companies.ToListAsync();
            return companies;
        }

        //List company by id 
        public async Task<Company> GetCompany(int id)
        {
            var company = await _appDbContext.Companies.FirstOrDefaultAsync(Company_x => Company_x.CompanyId == id);
            return company;
        }

        // Create company

        public async Task PostCompany(Company company)
        {
            _appDbContext.Companies.Add(company);
            await _appDbContext.SaveChangesAsync();

        }

        // Update company by id 
        public async Task<bool> UpdateCompany(Company company)
        {
            var up_company = await GetCompany(company.CompanyId);
            up_company.Name = company.Name;
            up_company.Description = company.Description;
            up_company.AddressId = company.AddressId;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove company by id
        public async Task<bool> Deletecompany(int id)
        {
            var up_company = await GetCompany(id);
            _appDbContext.Companies.Remove(up_company);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
