namespace RouteManagment.Core.Entities;

public partial class User : BaseEntity
{
 

    public int DocumentNumber { get; set; }

    public string? Password { get; set; }

    public virtual People DocumentNumberNavigation { get; set; } = null!;


}
