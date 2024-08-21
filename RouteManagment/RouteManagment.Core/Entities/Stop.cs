using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Stop : BaseEntity
{
    // public int StopId { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<RoutesStop> RoutesStops { get; set; } = new List<RoutesStop>();
}
