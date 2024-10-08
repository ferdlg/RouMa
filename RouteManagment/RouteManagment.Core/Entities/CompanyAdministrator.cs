namespace RouteManagment.Core.Entities;

public partial class CompanyAdministrator : BaseEntity
{
    public int DocumentNumber { get; set; }
    public int CompanyId { get; set; }
    public virtual People DocumentNumberNavigation { get; set; } = null!;
    public virtual Company CompanyIdNavigation { get; set; } = null!;


}
