using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class RolPermissionRepository : IRolPermissionRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public RolPermissionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all RolPermissions
        public async Task<IEnumerable<RolesPermission>> GetRolPermissions()
        {
            var rolPermissions = await _appDbContext.RolesPermissions.ToListAsync();
            return rolPermissions;
        }

        //List RolPermission by id 
        public async Task<RolesPermission> GetRolPermission(int id)
        {
            var rolPermission = await _appDbContext.RolesPermissions.FirstOrDefaultAsync(RolPermission_x => RolPermission_x.RolPermissionId == id);
            return rolPermission;
        }

        // Create RolPermission

        public async Task PostRolPermission(RolesPermission rolPermission)
        {
            _appDbContext.RolesPermissions.Add(rolPermission);
            await _appDbContext.SaveChangesAsync();

        }

        // Update rolPermission by id 
            public async Task<bool> UpdateRolPermission(RolesPermission rolPermission)
        {
            var up_rolPermission = await GetRolPermission(rolPermission.RolPermissionId);
            up_rolPermission.RolId = rolPermission.RolPermissionId;
            up_rolPermission.PermissionId = rolPermission.RolPermissionId;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove rolPermission by id
        public async Task<bool> DeleteRolPermission(int id)
        {
            var up_rolPermission = await GetRolPermission(id);
            _appDbContext.RolesPermissions.Remove(up_rolPermission);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
