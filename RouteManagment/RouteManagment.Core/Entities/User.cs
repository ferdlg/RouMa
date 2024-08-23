namespace RouteManagment.Core.Entities;

public partial class User : BaseEntity
{
    // public int UserId { get; set; }

    public int DocumentNumber { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<People> People { get; set; } = new List<People>();
    public virtual People DocumentNumberNavigation { get; set; } = null!;


}
