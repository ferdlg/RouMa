using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class TransportDto
    {
        public required string Plate { get; set; }

        public int Capacity { get; set; }

        public int StateId { get; set; }

        public int? RouteId { get; set; }

        public int? TransportTypeId { get; set; }
        public bool IsDelete { get; set; }


    }
}
