using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.DTOs
{
    public class PeopleDto
    {
        public int id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public int Phone { get; set; }

        public int? AddressId { get; set; }

        public int? DocumentTypeId { get; set; }

        public int? RolId { get; set; }



  
    }
}
