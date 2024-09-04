using ManejoRutas.Core.Interfaces;
using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.Interfaces
{
    public interface ITransportUnitOfWork : IDisposable
    {
        ITransportRepository TransportRepository { get; }
        IRepository<TransportState> TransporStateRepository { get; }
        IRepository<TransportRequest> TransportRequestRepository { get; }
        IRepository<TransportRequestState> TransportRequestStateRepository { get; }
        IRepository<TransportType> TransportTypeRepository { get; }


        void SaveChange();
        Task SaveChangesAsync();

    }
}
