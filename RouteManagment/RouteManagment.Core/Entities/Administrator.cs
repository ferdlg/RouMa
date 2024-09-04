namespace RouteManagment.Core.Entities;

public partial class Administrator : BaseEntity
{
    //public int AdministratorId { get; set; }

    public int DocumentNumber { get; set; }

    public virtual People DocumentNumberNavigation { get; set; } = null!;

}
