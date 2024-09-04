using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class StreetType : BaseEntity
{
    // public int StreetTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
