using AutoMapper;
using RouteManagment.Core.DTOs;
using RouteManagment.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            CreateMap<DocumentType, DocumentTypeDto>();
            CreateMap<DocumentTypeDto, DocumentType>();

            CreateMap<Driver, DriverDto>();
            CreateMap<DriverDto, Driver>();

            CreateMap<Person, PeopleDto>();
            CreateMap<PeopleDto, Person>();

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

            CreateMap<TransportState, TransportStateDto>();
            CreateMap<TransportStateDto, TransportState>();

            CreateMap<TransportType, TransportTypeDto>();
            CreateMap<TransportTypeDto, TransportType>();

        }
    }
}
