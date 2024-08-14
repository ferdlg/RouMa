using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class  RolRepository : IRolRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public RolRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all roles
        public async Task<IEnumerable<Role>> GetRoles()
        {
            var roles = await _appDbContext.Roles.ToListAsync();
            return roles;
        }

        //List rol by id 
        public async Task<Role> GetRol(int id)
        {
            var roles = await _appDbContext.Roles.FirstOrDefaultAsync(rol_x => rol_x.RolId == id);
            return roles;
        }

        // Create rol

        public async Task PostRol(Role rol)
        {
            _appDbContext.Roles.Add(rol);
            await _appDbContext.SaveChangesAsync();

        }

        //Update rol 

        public async Task<Role> PutRol(int id)
        {
            var rol = _appDbContext.Roles.FirstOrDefaultAsync(rol_x => rol_x.RolId == id);
            _appDbContext.Roles.Update(await rol);
            await _appDbContext.SaveChangesAsync();
            return await rol;
        }

        //Remove rol by id 

        public async Task<Role> DeleteRol(int id)
        {
            var rol = await _appDbContext.Roles.FirstOrDefaultAsync(rol_x => rol_x.RolId == id);
            _appDbContext.Roles.Remove(rol);
            await _appDbContext.SaveChangesAsync();
            return rol;
        }
    }
}
