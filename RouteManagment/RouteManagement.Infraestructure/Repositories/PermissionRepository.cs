using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public PermissionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all Permissions
        public async Task<IEnumerable<Permission>> GetPermissions()
        {
            var permissions = await _appDbContext.Permissions.ToListAsync();
            return permissions;
        }

        //List Permission by id 
        public async Task<Permission> GetPermission(int id)
        {
            var permission = await _appDbContext.Permissions.FirstOrDefaultAsync(Permission_x => Permission_x.PermissionId== id);
            return permission;
        }

        // Create Permission

        public async Task PostPermission(Permission permission)
        {
            _appDbContext.Permissions.Add(permission);
            await _appDbContext.SaveChangesAsync();

        }

        //Update Permission 

        public async Task<Permission> PutPermission(int id)
        {
            var permission = _appDbContext.Permissions.FirstOrDefaultAsync(Permission_x => Permission_x.PermissionId == id);
            _appDbContext.Permissions.Update(await permission);
            await _appDbContext.SaveChangesAsync();
            return await permission;
        }

        //Remove Permission by id 

        public async Task<Permission> DeletePermission(int id)
        {
            var permission = await _appDbContext.Permissions.FirstOrDefaultAsync(Permission_x => Permission_x.PermissionId == id);
            _appDbContext.Permissions.Remove(permission);
            await _appDbContext.SaveChangesAsync();
            return permission;
        }
    }
}
