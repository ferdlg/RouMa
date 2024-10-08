﻿using Microsoft.AspNetCore.Http.HttpResults;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Exceptions;
using RouteManagment.Core.Interfaces;

namespace RouteManagment.Core.Services
{
    public class RouteService : IRouteService
    {
        private readonly IRouteUnitOfWork _unitOfWork;

        public RouteService(IRouteUnitOfWork iunitOfWork)
        {
            _unitOfWork = iunitOfWork;
        }
        private void ValidationOrigenDestination(int origen, int destination)
        {
            if (origen == destination)
            {
                throw new BussinesExceptions(ErrorCode.InvaliData, message: "The origin and destination cannot be the same");
            }

        }
        public IEnumerable<Route> GetRoutes()
        {
            return  _unitOfWork.RouteRepository.GetAll();
        }
        public async Task<Route> GetRouteById(int id)
        {
            return await _unitOfWork.RouteRepository.GetById(id);
        }

        public async Task InsertRoute(Route route)
        {
           var origen = route.AddressOriginId;
           var destination = route.AddressHeadQuarterId;

           ValidationOrigenDestination(origen, destination);

           await _unitOfWork.RouteRepository.Add(route);
           await _unitOfWork.SaveChanguesAsync();
            
        }
        public async Task<bool> Update(Route route)
        {
            var origen = route.AddressOriginId;
            var destination = route.AddressHeadQuarterId;

            ValidationOrigenDestination(origen, destination);

            _unitOfWork.RouteRepository.Update(route);
            await _unitOfWork.SaveChanguesAsync();
            return true;
        }
        public async Task<bool> Delete(int id)
        { 
           await _unitOfWork.RouteRepository.Delete(id);
           await _unitOfWork.SaveChanguesAsync();
            return true;
        }
    }
    public class BaseServiceR <T>: IServiceR<T> where T : BaseEntity
    {
        private readonly IRouteUnitOfWork _unitOfWork;
        public BaseServiceR(IRouteUnitOfWork iunitOfWork)
        {
            _unitOfWork = iunitOfWork;
        }

        public IEnumerable<T> GetAll()
        {
            return _unitOfWork.GetRepository<T>().GetAll();

        }
        public async Task<T> GetById(int id)
        {
            return await _unitOfWork.GetRepository<T>().GetById(id);

        }

        public async Task<T> Add(T entity)
        {
            await _unitOfWork.GetRepository<T>().Add(entity);
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _unitOfWork.GetRepository<T>().Update(entity);
            await _unitOfWork.SaveChanguesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var entity = await _unitOfWork.GetRepository<T>().GetById(id);
            if (entity != null) {

                await _unitOfWork.GetRepository<T>().Delete(id);
                await _unitOfWork.SaveChanguesAsync();
            }

            return entity;
        }


    }
}
