namespace RouteManagment.Core.DTOs
{
    public class RouteStopDto
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int StopId { get; set; }
        public bool IsDelete { get; set; }

    }
}
