using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Driver
{
    public int DriverId { get; set; }

    public int DocumentNumber { get; set; }

    public virtual Employee DocumentNumberNavigation { get; set; } = null!;
}
