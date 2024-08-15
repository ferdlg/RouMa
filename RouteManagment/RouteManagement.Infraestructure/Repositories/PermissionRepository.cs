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

        // Update permission by id 
        public async Task<bool> UpdatePermission(Permission permission)
        {
            var up_permission = await GetPermission(permission.PermissionId);
            up_permission.Name = permission.Name;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove permission by id
        public async Task<bool> DeletePermission(int id)
        {
            var up_permission = await GetPermission(id);
            _appDbContext.Permissions.Remove(up_permission);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
