namespace RouteManagment.Core.Entities;

public partial class Administrator
{
    public int AdministratorId { get; set; }

    public int DocumentNumber { get; set; }

    public virtual Employee DocumentNumberNavigation { get; set; } = null!;

    public virtual ICollection<TransportRequest> TransportRequests { get; set; } = new List<TransportRequest>();
}
