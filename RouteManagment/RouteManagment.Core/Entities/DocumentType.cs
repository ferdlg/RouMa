namespace RouteManagment.Core.Entities;

public partial class DocumentType
{
    public int DocumentTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
