using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class  PassengerRepository : IPassengerRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public PassengerRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all Passengers
        public async Task<IEnumerable<Passenger>> GetPassengers()
        {
            var Passengers = await _appDbContext.Passengers.ToListAsync();
            return Passengers;
        }

        //List Passenger by id 
        public async Task<Passenger> GetPassenger(int id)
        {
            var passenger = await _appDbContext.Passengers.FirstOrDefaultAsync(Passenger_x => Passenger_x.PassengerId == id);
            return passenger;
        }

        // Create Passenger

        public async Task PostPassenger(Passenger Passenger)
        {
            _appDbContext.Passengers.Add(Passenger);
            await _appDbContext.SaveChangesAsync();

        }
        // Update passenger by id 
        public async Task<bool> UpdatePassenger(Passenger passenger)
        {
            var up_passenger = await GetPassenger(passenger.PassengerId);
            up_passenger.DocumentNumber = passenger.DocumentNumber;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove passenger by id
        public async Task<bool> DeletePassenger(int id)
        {
            var up_passenger = await GetPassenger(id);
            _appDbContext.Passengers.Remove(up_passenger);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
