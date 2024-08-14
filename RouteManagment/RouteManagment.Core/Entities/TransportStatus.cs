using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class TransportStatus
{
    public int StatusId { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
