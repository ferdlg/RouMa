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

        //Update company 

        public async Task<Company> PutCompany(int id)
        {
            var company = _appDbContext.Companies.FirstOrDefaultAsync(Company_x => Company_x.CompanyId == id);
            _appDbContext.Companies.Update(await company);
            await _appDbContext.SaveChangesAsync();
            return await company;
        }

        //Remove company by id 

        public async Task<Company> DeleteCompany(int id)
        {
            var company = await _appDbContext.Companies.FirstOrDefaultAsync(Company_x => Company_x.CompanyId == id);
            _appDbContext.Companies.Remove(company);
            await _appDbContext.SaveChangesAsync();
            return company;
        }
    }
}
