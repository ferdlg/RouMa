using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportStateRepository
    {
        Task<IEnumerable<TransportState>> GetTransportStates();
        Task<TransportState> GetTransportState(int id);
        Task PostTransportState(TransportState TransportState);
        Task<bool> UpdatetransportState(TransportState transportState);

        Task<bool> DeleteTransportState(int id);
    }
}
