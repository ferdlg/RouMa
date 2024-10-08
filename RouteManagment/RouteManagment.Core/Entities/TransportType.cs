using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class TransportType : BaseEntity
{
 
    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<TransportRequest> TransportRequests { get; set; } = new List<TransportRequest>();

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
