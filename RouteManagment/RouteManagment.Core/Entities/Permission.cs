using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Permission : BaseEntity
{
   // public int PermissionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>();
}
