using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManejoRutas.Core.Interfaces
{
    public interface IDrivingLicenseTypeRepository
    {
        Task<IEnumerable<DrivingLicenseType>> GetDrivingLicenseTypes();

        Task<DrivingLicenseType> GetDrivingLicenseType(int id);

        Task PostDrivingLicenseType(DrivingLicenseType DrivingLicenseType);

        Task<bool> UpdateDrivingLicenseType(DrivingLicenseType DrivingLicenseType);

        Task<bool> DeleteDrivingLicenseType(int id);

    }
}
