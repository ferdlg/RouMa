﻿namespace RouteManagment.Core.Entities;

public partial class Headquarter
{
    public int HeadQuarterId { get; set; }

    public int AddressId { get; set; }

    public int CompanyId { get; set; }

    public virtual ICollection<Address> Addresses{ get; set; } = new List<Address>();
    public virtual ICollection<Company> Companies{ get; set; } = new List<Company>();

}
