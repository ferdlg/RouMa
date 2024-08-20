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
    public class TransportRequestStateRepository : ITransportRequestStateRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public TransportRequestStateRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all TransportRequestState
        public async Task<IEnumerable<TransportRequestState>> GetTransportRequestStates()
        {
            var TransportRequestState = await _appDbContext.TransportRequestStates.ToListAsync();
            return TransportRequestState;
        }

        //List TransportRequestState by id 
        public async Task<TransportRequestState> GetTransportRequestState(int id)
        {
            var TransportRequestState = await _appDbContext.TransportRequestStates.FirstOrDefaultAsync(TransportRequestState_x => TransportRequestState_x.StateId== id);
            return TransportRequestState;
        }

        // Create TransportRequestState

        public async Task PostTransportRequestState(TransportRequestState TransportRequestState)
        {
            _appDbContext.TransportRequestStates.Add(TransportRequestState);
            await _appDbContext.SaveChangesAsync();

        }

        // Update TransportRequestState by id 
        public async Task<bool> UpdateTransportRequestState(TransportRequestState TransportRequestState)
        {
            var up_TransportRequestState = await GetTransportRequestState(TransportRequestState.StateId);
            up_TransportRequestState.State = TransportRequestState.State;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove TransportRequestState by id
        public async Task<bool> DeleteTransportRequestState(int id)
        {
            var up_TransportRequestState = await GetTransportRequestState(id);
            _appDbContext.TransportRequestStates.Remove(up_TransportRequestState);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }

}
