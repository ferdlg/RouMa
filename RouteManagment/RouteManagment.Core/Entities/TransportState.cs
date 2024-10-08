using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class TransportState : BaseEntity
{
 
    public string State { get; set; } = null!;

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
