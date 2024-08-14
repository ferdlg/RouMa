using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Route
{
    public int RouteId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<RoutesStop> RoutesStops { get; set; } = new List<RoutesStop>();

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
