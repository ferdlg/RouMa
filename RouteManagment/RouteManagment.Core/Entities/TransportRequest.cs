using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class TransportRequest : BaseEntity
{

    public DateTime Date { get; set; }

    public string? Description { get; set; }

    public int TransportTypeId { get; set; }

    public int CompanyId { get; set; }

    public int StateId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual TransportRequestState? TransportRequestState { get; set; }
    public virtual TransportType TransportType { get; set; } = null!;
}
