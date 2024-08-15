using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class AdministratorRepository : IAdministratorRepository 
    {
            // Logic for CRUD methods
            private readonly AppDbContext _appDbContext;

            public AdministratorRepository(AppDbContext appDbContext)
            {
                _appDbContext = appDbContext;

            }

            //List all administrators

            public async Task<IEnumerable<Administrator>> GetAdministrators()
            {
                var administrators = await _appDbContext.Administrators.ToListAsync();
                return administrators;
            }

            //List administrator by id

            public async Task<Administrator> GetAdministrator(int id)
            {
                var administrator = await _appDbContext.Administrators.FirstOrDefaultAsync(Administrator_x => Administrator_x.AdministratorId == id);
                return administrator;
            }

            // Create administrator
            public async Task PostAdministrator(Administrator administrator)
            {
                _appDbContext.Administrators.Add(administrator);
                await _appDbContext.SaveChangesAsync();
            }
            // Update administrator by id 
            public async Task<bool> UpdateAdministrator(Administrator administrator)
            {
                var up_administrator = await GetAdministrator(administrator.AdministratorId);
                up_administrator.DocumentNumber= administrator.DocumentNumber;
             
                int rows = await _appDbContext.SaveChangesAsync();
                return rows > 0;
            }


            // Remove administrator by id
            public async Task<bool> DeleteAdministrator(int id)
            {
                var up_administrator = await GetAdministrator(id);
                _appDbContext.Administrators.Remove(up_administrator);
                int rows = await _appDbContext.SaveChangesAsync();
                return rows > 0;
            }

    }
}
