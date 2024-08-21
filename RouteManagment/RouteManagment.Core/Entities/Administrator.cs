namespace RouteManagment.Core.Entities;

public partial class Administrator : BaseEntity
{
    //public int AdministratorId { get; set; }

    public int DocumentNumber { get; set; }

    public virtual Person DocumentNumberNavigation { get; set; } = null!;

    public virtual ICollection<TransportRequest> TransportRequests { get; set; } = new List<TransportRequest>();
}
