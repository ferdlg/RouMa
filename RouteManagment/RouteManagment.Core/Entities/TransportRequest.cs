using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class TransportRequest : BaseEntity
{
    // public int RequestId { get; set; }

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public int TransportTypeId { get; set; }

    public int CompanyId { get; set; }

    public int AdministratorId { get; set; }

    public virtual Administrator Administrator { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual TransportType TransportType { get; set; } = null!;
}
