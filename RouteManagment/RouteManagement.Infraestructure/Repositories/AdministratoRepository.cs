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
            // Update Administrator by id 

            public async Task<Administrator> PutAdministrator(int id)
            {
                var administrator = await _appDbContext.Administrators.FirstOrDefaultAsync(administrator_x => administrator_x.AdministratorId == id);
                _appDbContext.Administrators.Update(administrator);
                await _appDbContext.SaveChangesAsync();
                return administrator;

            }

            // Remove Administrator by id
            public async Task<Administrator> DeleteAdministrator(int id)
            {
                var administrator = await _appDbContext.Administrators.FirstOrDefaultAsync(Administrator_x => Administrator_x.AdministratorId == id);
                _appDbContext.Administrators.Remove(administrator);
                await _appDbContext.SaveChangesAsync();
                return administrator;

            }

    }
}
