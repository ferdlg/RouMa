using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class StopDto
    {
        public int Id { get; set; }

        public int AddressId { get; set; }
        public bool IsDelete { get; set; }

    }
}
