using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class Driver : BaseEntity
{
    //public int DriverId { get; set; }

    public int DrivingLicenseNumber { get; set; }

    public int DocumentNumber { get; set; }

    public int TypeLicenseId { get; set; }

    public string ? PlateTransport {  get; set; }

    public virtual People DocumentNumberNavigation { get; set; } = null!;

    public virtual DrivingLicenseType? DrivingLicenseType { get; set; }

    public virtual Transport? Plate { get; set; } = null!;

}
