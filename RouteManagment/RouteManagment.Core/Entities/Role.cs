using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Role : BaseEntity
{
    // public int RolId { get; set; }

    public string Name { get; set; } = null!;


    public virtual ICollection<People> People { get; set; } = new List<People>();

    public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>();
}
