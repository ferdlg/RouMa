using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class RouteStopDto
    {
        public int RouteStopId { get; set; }

        public int RouteId { get; set; }

        public int StopId { get; set; }
    }
}
