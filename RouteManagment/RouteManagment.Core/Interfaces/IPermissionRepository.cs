using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<Permission>> GetPermissions();
        Task<Permission> GetPermission(int id);
        Task PostPermission(Permission Permission);
        Task<bool> UpdatePermission(Permission permission);

        Task<bool> DeletePermission(int id);
    }
}
