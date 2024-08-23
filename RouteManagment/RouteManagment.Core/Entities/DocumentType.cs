namespace RouteManagment.Core.Entities;

public partial class DocumentType :BaseEntity
{
    //public int DocumentTypeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<People> People { get; set; } = new List<People>();
}
