﻿using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Role : BaseEntity
{
    // public int RolId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<RolesPermission> RolesPermissions { get; set; } = new List<RolesPermission>();
}
