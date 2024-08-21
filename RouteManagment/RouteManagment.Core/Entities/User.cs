namespace RouteManagment.Core.Entities;

public partial class User : BaseEntity
{
    // public int UserId { get; set; }

    public int DocumentNumber { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
