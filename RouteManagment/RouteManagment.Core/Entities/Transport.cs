using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Transport
{
    public int Plate { get; set; }

    public int Capacity { get; set; }

    public int StatusId { get; set; }

    public int? RouteId { get; set; }

    public int? TransportTypeId { get; set; }

    public int? CompanyId { get; set; }

    public virtual Company? Company { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

    public virtual Route? Route { get; set; }

    public virtual TransportStatus Status { get; set; } = null!;

    public virtual TransportType? TransportType { get; set; }
}
