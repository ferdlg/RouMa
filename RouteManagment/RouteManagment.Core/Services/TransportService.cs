﻿using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;

namespace RouteManagment.Core.Services
{
    public class TransportService : ITransportService
    {
        IEnumerable<Transport> ITransportService.GetTransports()
        {
            throw new NotImplementedException();
        }
        public Task<Transport> GetTransport(string? plate)
        {
            throw new NotImplementedException();
        }
        public Task PostTransport(Transport Transport)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTransport(Transport transport)
        {
            throw new NotImplementedException();
        }
        public Task<bool> DeleteTransport(string? plate)
        {
            throw new NotImplementedException();
        }

    }
}
