using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class TransportState : BaseEntity
{
    // public int StateId { get; set; }

    public string State { get; set; } = null!;

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
