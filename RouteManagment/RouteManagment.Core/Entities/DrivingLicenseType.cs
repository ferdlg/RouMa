namespace RouteManagment.Core.Entities;

public partial class DrivingLicenseType : BaseEntity
{
    //public int TypeLicenseId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Driver> Drivers { get; set; } = new List<Driver>();
}
