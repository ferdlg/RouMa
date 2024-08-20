using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportRequestStateRepository
    {
        Task<IEnumerable<TransportRequestState>> GetTransportRequestStates();
        Task<TransportRequestState> GetTransportRequestState(int id);
        Task PostTransportRequestState(TransportRequestState TransportRequestState);
        Task<bool> UpdateTransportRequestState(TransportRequestState TransportRequestState);
        Task<bool> DeleteTransportRequestState(int id);
    }
}
