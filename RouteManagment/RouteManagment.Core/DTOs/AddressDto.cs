using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class AddressDto
    {
        public int AddressId { get; set; }

        public string? StreetName { get; set; }

        public int? StreetNumber { get; set; }

        public string? Quadrant { get; set; }

        public int? Plate { get; set; }

        public string? Prefix { get; set; }

        public int StreetTypeId { get; set; }
    }
}
