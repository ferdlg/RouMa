using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Passenger
{
    public int PassengerId { get; set; }

    public int DocumentNumber { get; set; }

    public virtual Employee DocumentNumberNavigation { get; set; } = null!;
}
