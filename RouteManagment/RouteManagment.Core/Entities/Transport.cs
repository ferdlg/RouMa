﻿using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Transport
{
    public int Plate { get; set; }

    public int Capacity { get; set; }

    public int StateId { get; set; }

    public int? RouteId { get; set; }

    public int? TransportTypeId { get; set; }

    public virtual ICollection<Person> Employees { get; set; } = new List<Person>();

    public virtual Route? Route { get; set; }

    public virtual TransportState State { get; set; } = null!;

    public virtual TransportType? TransportType { get; set; }
}
