using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Address : BaseEntity
{
   // public int AddressId { get; set; }

    public string? StreetName { get; set; }

    public int? StreetNumber { get; set; }

    public string? Quadrant { get; set; }

    public int? Plate { get; set; }

    public string? Prefix { get; set; }

    public int StreetTypeId { get; set; }

    public virtual ICollection<Headquarter> Headquarters { get; set; } = new List<Headquarter>();

    public virtual ICollection<People> People { get; set; } = new List<People>();
    public virtual ICollection<Route> Routes{ get; set; } = new List<Route>();

    public virtual ICollection<Stop> Stops { get; set; } = new List<Stop>();

    public virtual StreetType StreetType { get; set; } = null!;
}
