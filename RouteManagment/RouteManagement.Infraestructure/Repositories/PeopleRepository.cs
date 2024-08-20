using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class  PeopleRepository : IPeopleRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public PeopleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all people
        public async Task<IEnumerable<Person>> GetPeople()
        {
            var person = await _appDbContext.People.ToListAsync();
            return person;
        }

        //List person by id 
        public async Task<Person> GetPerson(int id)
        {
            var person = await _appDbContext.People.FirstOrDefaultAsync(person_x => person_x.DocumentNumber == id);
            return person;
        }

        // Create person

        public async Task PostPerson(Person person)
        {
            _appDbContext.People.Add(person);
            await _appDbContext.SaveChangesAsync();

        }

        // Update person by id 
        public async Task<bool> UpdatePerson(Person person)
        {
            var up_person = await GetPerson(person.DocumentNumber);
            up_person.DocumentNumber = person.DocumentNumber;
            up_person.FirstName = person.FirstName;
            up_person.LastName = person.LastName;
            up_person.Email = person.Email;
            up_person.Phone = person.Phone;
            up_person.AddressId = person.AddressId;
            up_person.DocumentTypeId = person.DocumentTypeId;
            up_person.RolId = person.RolId;
            up_person.CompanyId = person.CompanyId;


            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove person by id
        public async Task<bool> DeletePerson(int id)
        {
            var up_person = await GetPerson(id);
            _appDbContext.People.Remove(up_person);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
