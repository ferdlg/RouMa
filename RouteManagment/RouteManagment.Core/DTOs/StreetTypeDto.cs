using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class StreetTypeDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public bool IsDelete { get; set; }

    }
}
