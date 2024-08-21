using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Route : BaseEntity
{
    // public int RouteId { get; set; }

    public int AddressOriginId { get; set; }

    public int AddressHeadQuarterId { get; set; }

    public virtual Address AddressIdNavigation{ get; set; } = null!;

    public virtual Headquarter HeadQuarterIdNavigation{ get; set; } = null!;

    public virtual ICollection<RoutesStop> RoutesStops { get; set; } = new List<RoutesStop>();

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
