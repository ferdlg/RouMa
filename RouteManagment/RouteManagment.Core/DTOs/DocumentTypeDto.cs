namespace RouteManagment.Core.DTOs
{
    public class DocumentTypeDto
    {
        public int DocumentTypeId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }
    }
}
