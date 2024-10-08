using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Permission : BaseEntity
{

    public string Name { get; set; } = null!;

    public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>();
}
