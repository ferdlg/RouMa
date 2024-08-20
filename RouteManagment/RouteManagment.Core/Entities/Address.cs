using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Address
{
    public int AddressId { get; set; }

    public string? StreetName { get; set; }

    public int? StreetNumber { get; set; }

    public string? Quadrant { get; set; }

    public int? Plate { get; set; }

    public string? Prefix { get; set; }

    public int StreetTypeId { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual ICollection<Person> People { get; set; } = new List<Person>();

    public virtual ICollection<Stop> Stops { get; set; } = new List<Stop>();

    public virtual StreetType StreetType { get; set; } = null!;
}
