﻿using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IStopRepository
    {
        Task<IEnumerable<Stop>> GetStops();
        Task<Stop> GetStop(int id);
        Task PostStop(Stop Stop);
        Task<Stop> PutStop(int id);

        Task<Stop> DeleteStop(int id);
    }
}
