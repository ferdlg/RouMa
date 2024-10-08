﻿using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Transport 
{
    public required string Plate { get; set; }

    public int Capacity { get; set; }

    public int StateId { get; set; }

    public int? RouteId { get; set; }

    public int? TransportTypeId { get; set; }
    public bool IsDelete { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual Route? Route { get; set; }

    public virtual TransportState State { get; set; } = null!;

    public virtual TransportType? TransportType { get; set; }
}
