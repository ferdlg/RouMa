using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Passenger : BaseEntity
{
    // public int PassengerId { get; set; }

    public int DocumentNumber { get; set; }

    public int CompanyId { get; set; }
    public int RouteId { get; set; }


    public virtual People DocumentNumberNavigation { get; set; } = null!;
    public virtual Company CompanyIdNavigation { get; set; } = null!;
    public virtual Route RouteIdNavigation { get; set; } = null!;

}
