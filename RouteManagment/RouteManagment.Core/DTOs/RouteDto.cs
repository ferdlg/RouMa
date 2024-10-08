using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class RouteDto
    {
        public int AddressOriginId { get; set; }

        public int AddressHeadQuarterId { get; set; }

        public bool IsDelete { get; set; }

    }
}
