using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    
    public class PassengerDto
    {
        public int Id { get; set; }

        public int DocumentNumber { get; set; }

        public int CompanyId { get; set; }
        public int RouteId { get; set; }

    }
}
