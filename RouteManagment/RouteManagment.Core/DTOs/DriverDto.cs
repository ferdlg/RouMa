using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class DriverDto
    {
        public int Id { get; set; }

        public int DrivingLicenseNumber { get; set; }

        public int DocumentNumber { get; set; }

        public int TypeLicenseId { get; set; }

        public string? PlateTransport { get; set; }
    }
}
