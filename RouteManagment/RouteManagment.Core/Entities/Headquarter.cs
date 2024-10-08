namespace RouteManagment.Core.Entities;

public partial class Headquarter : BaseEntity
{

    public int AddressId { get; set; }

    public int CompanyId { get; set; }

    public virtual ICollection<Address> Addresses{ get; set; } = new List<Address>();
    public virtual ICollection<Company> Companies{ get; set; } = new List<Company>();
    public virtual ICollection<Route> Routes{ get; set; } = new List<Route>();


}
