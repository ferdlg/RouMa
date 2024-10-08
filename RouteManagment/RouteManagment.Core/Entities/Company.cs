using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Company : BaseEntity
{

    public string Name { get; set; } = null!;


    public virtual ICollection<TransportRequest> TransportRequests { get; set; } = new List<TransportRequest>();

    public virtual ICollection<Headquarter> Headquarters{ get; set; } = new List<Headquarter>();
    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
    public virtual ICollection<CompanyAdministrator> CompanyAdministrators { get; set; } = new List<CompanyAdministrator>();


}
