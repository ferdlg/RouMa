using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class TransportRequestDto
    {
        public int RequestId { get; set; }

        public DateTime Date { get; set; }

        public string? Description { get; set; }

        public int TransportTypeId { get; set; }

        public int CompanyId { get; set; }

        public int AdministratorId { get; set; }
    }
}
