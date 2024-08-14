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

        //Update RolPermission 

        public async Task<RolesPermission> PutRolPermission(int id)
        {
            var rolPermission = _appDbContext.RolesPermissions.FirstOrDefaultAsync(RolPermission_x => RolPermission_x.RolPermissionId == id);
            _appDbContext.RolesPermissions.Update(await rolPermission);
            await _appDbContext.SaveChangesAsync();
            return await rolPermission;
        }

        //Remove RolPermission by id 

        public async Task<RolesPermission> DeleteRolPermission(int id)
        {
            var rolPermission = await _appDbContext.RolesPermissions.FirstOrDefaultAsync(RolPermission_x => RolPermission_x.RolPermissionId == id);
            _appDbContext.RolesPermissions.Remove(rolPermission);
            await _appDbContext.SaveChangesAsync();
            return rolPermission;
        }
    }
}
