using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface ITransportStatusRepository
    {
        Task<IEnumerable<TransportStatus>> GetTransportStatuss();
        Task<TransportStatus> GetTransportStatus(int id);
        Task PostTransportStatus(TransportStatus TransportStatus);
        Task<bool> UpdatetransportStatus(TransportStatus transportStatus);

        Task<bool> DeleteTransportStatus(int id);
    }
}
