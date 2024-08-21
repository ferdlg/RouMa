using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Company : BaseEntity
{
    //public int CompanyId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Person> Employees { get; set; } = new List<Person>();

    public virtual ICollection<TransportRequest> TransportRequests { get; set; } = new List<TransportRequest>();

    public virtual ICollection<Transport> Transports { get; set; } = new List<Transport>();
}
