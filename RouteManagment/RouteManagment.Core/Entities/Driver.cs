using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Driver
{
    public int DriverId { get; set; }

    public int DrivingLicenseNumber { get; set; }

    public int DocumentNumber { get; set; }

    public int TypelicenseId { get; set; }

    public string ? PlateTransport {  get; set; }

    public virtual Person DocumentNumberNavigation { get; set; } = null!;

    public virtual DrivingLicenseType TypeLicenseIdNavigation { get; set; } = null!;

    public virtual Transport PlateTransportNavigation { get; set; } = null!;

}
