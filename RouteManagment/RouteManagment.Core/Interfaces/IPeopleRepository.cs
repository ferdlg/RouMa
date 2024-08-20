using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IPeopleRepository
    {
        Task<IEnumerable<Person>> GetPeople();
        Task<Person> GetPerson(int id);
        Task PostPerson(Person person);
        Task<bool> UpdatePerson(Person person);

        Task<bool> DeletePerson(int id);
    }
}
