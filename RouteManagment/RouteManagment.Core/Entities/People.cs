using System;
using System.Collections.Generic;

namespace RouteManagment.Core.Entities;

public partial class People : BaseEntity
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Phone { get; set; }

    public int? AddressId { get; set; }

    public int? DocumentTypeId { get; set; }

    public int? RolId { get; set; }


    public virtual Address? Address { get; set; }

    public virtual ICollection<Administrator> Administrators { get; set; } = new List<Administrator>();

    public virtual DocumentType? DocumentType { get; set; }

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();

    public virtual ICollection<Passenger> Passengers { get; set; } = new List<Passenger>();
    public virtual ICollection<CompanyAdministrator> CompanyAdministrators { get; set; } = new List<CompanyAdministrator>();

    public virtual Role? Rol { get; set; }
    public virtual ICollection<User> Users{ get; set; } = new List<User>();


}
