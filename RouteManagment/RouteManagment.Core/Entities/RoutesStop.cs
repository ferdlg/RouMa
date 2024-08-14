using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class RoutesStop
{
    public int RouteStopId { get; set; }

    public int RouteId { get; set; }

    public int StopId { get; set; }

    public virtual Route Route { get; set; } = null!;

    public virtual Stop Stop { get; set; } = null!;
}
