namespace RouteManagment.Core.DTOs
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public int AddressId { get; set; }
    }
}
