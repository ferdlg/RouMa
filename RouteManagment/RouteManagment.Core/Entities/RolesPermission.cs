using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class RolesPermission
{
    public int RolPermissionId { get; set; }

    public int PermissionId { get; set; }

    public int RolId { get; set; }

    public virtual Permission Permission { get; set; } = null!;

    public virtual Role Rol { get; set; } = null!;
}
