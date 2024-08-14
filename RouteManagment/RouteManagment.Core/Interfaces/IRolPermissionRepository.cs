﻿using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IRolPermissionRepository
    {
        Task<IEnumerable<RolesPermission>> GetRolPermissions();
        Task<RolesPermission> GetRolPermission(int id);
        Task PostRolPermission(RolesPermission RolPermission);
        Task<RolesPermission> PutRolPermission(int id);

        Task<RolesPermission> DeleteRolPermission(int id);
    }
}