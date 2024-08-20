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
    public class TransportStateRepository : ITransportStateRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public TransportStateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all TransportState
        public async Task<IEnumerable<TransportState>> GetTransportStates()
        {
            var transportState = await _appDbContext.TransportStates.ToListAsync();
            return transportState;
        }

        //List TransportState by id 
        public async Task<TransportState> GetTransportState(int id)
        {
            var transportState = await _appDbContext.TransportStates.FirstOrDefaultAsync(TransportState_x => TransportState_x.StateId== id);
            return transportState;
        }

        // Create TransportState

        public async Task PostTransportState(TransportState TransportState)
        {
            _appDbContext.TransportStates.Add(TransportState);
            await _appDbContext.SaveChangesAsync();

        }

        // Update transportState by id 
        public async Task<bool> UpdatetransportState(TransportState transportState)
        {
            var up_transportState = await GetTransportState(transportState.StateId);
            up_transportState.State = transportState.State;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove transportState by id
        public async Task<bool> DeleteTransportState(int id)
        {
            var up_transportState = await GetTransportState(id);
            _appDbContext.TransportStates.Remove(up_transportState);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
