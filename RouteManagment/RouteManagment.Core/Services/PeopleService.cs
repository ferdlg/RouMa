using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.Services
{
    public class PeopleService : IPeopleService
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<People> GetPeople()
        {
            throw new NotImplementedException();
        }

        public Task<People> GetPeopleById(int id)
        {
            throw new NotImplementedException();
        }

        public Task InsertPeople(People people)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(People people)
        {
            throw new NotImplementedException();
        }
    }
}
