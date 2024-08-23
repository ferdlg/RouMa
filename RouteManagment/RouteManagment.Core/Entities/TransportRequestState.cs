using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class TransportRequestState : BaseEntity
{

    public string? State { get; set; }

    public virtual ICollection<TransportRequest> TransportRequests { get; set; } = new List<TransportRequest>();
}
