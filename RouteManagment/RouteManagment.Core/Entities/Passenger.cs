using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Passenger : BaseEntity
{
    // public int PassengerId { get; set; }

    public int DocumentNumber { get; set; }

    public virtual Person DocumentNumberNavigation { get; set; } = null!;
}
