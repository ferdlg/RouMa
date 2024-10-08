using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class TransportRequestStateDto
    {
        public int Id { get; set; }

        public string State { get; set; } = null!;
        public bool IsDelete { get; set; }

    }
}
