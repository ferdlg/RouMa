using AutoMapper;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;

namespace RouteManagement.Infraestructure.Mappings
{
    public class AutomappingProfile : Profile
    {
        public AutomappingProfile()
        {
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();

            CreateMap<Administrator, AdministratorDto>();
            CreateMap<AdministratorDto, Administrator>();

            CreateMap<Company, CompanyDto>();
            CreateMap<CompanyDto, Company>();

            CreateMap<CompanyAdministrator, CompanyAdminDto>();
            CreateMap<CompanyAdminDto, CompanyAdministrator>();

            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<DocumentTypeDto, DocumentType>();

            CreateMap<Driver, DriverDto>();
            CreateMap<DriverDto, Driver>();

            CreateMap<DrivingLicenseType, DrivingLicenseTypeDto>();
            CreateMap<DrivingLicenseTypeDto, DrivingLicenseType>();

            CreateMap<Headquarter, HeadquarterDto>();
            CreateMap<HeadquarterDto, Headquarter>();

            CreateMap<People, PeopleDto>();
            CreateMap<PeopleDto, People>();

            CreateMap<Passenger, PassengerDto>();
            CreateMap<PassengerDto, Passenger>();

            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionDto, Permission>();

            CreateMap<RolesPermission, RolPermisionDto>();
            CreateMap<RolPermisionDto, RolPermisionDto>();

            CreateMap<Role, RolDto>();
            CreateMap<RolDto, Role>();

            CreateMap<Route, RouteDto>();
            CreateMap<RouteDto, Route>();

            CreateMap<RoutesStop, RouteStopDto>();
            CreateMap<RouteStopDto, RoutesStop>();

            CreateMap<Stop, StopDto>();
            CreateMap<StopDto, Stop>();

            CreateMap<StreetType, StreetTypeDto>();
            CreateMap<StreetTypeDto, StreetTypeDto>();

            CreateMap<Transport, TransportDto>();
            CreateMap<TransportDto, Transport>();  

            CreateMap<TransportRequest, TransportRequestDto>();
            CreateMap<TransportRequestDto, TransportRequestDto>();

            CreateMap<TransportRequestState, TransportRequestStateDto>();
            CreateMap<TransportRequestStateDto, TransportRequestState>();

            CreateMap<TransportState, TransportStateDto>();
            CreateMap<TransportStateDto, TransportState>();

            CreateMap<TransportType, TransportTypeDto>();
            CreateMap<TransportTypeDto, TransportType>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}
