using ManejoRutas.Core.Interfaces;
using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteManagment.Core.Interfaces
{
    public interface ITransportUnitOfWork
    {
        ITransportRepository TransportRepository { get; }
        IRepository<TransportRequest> TransportRequestRepository { get; }
        IRepository<Driver> DriverRepository { get; }
        IRepository<Passenger> PassengerRepository { get; }
    }
}
