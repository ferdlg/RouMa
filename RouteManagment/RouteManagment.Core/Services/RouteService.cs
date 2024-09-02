using RouteManagment.Core.Entities;
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
        public async Task<IEnumerable<Route>> GetRoutes()
        {
            return await _unitOfWork.RouteRepository.GetAll();
        }
        public async Task<Route> GetRouteById(int id)
        {
            return await _unitOfWork.RouteRepository.GetById(id);
        }
        public async Task InsertRoute(Route route)
        {
            await _unitOfWork.RouteRepository.Add(route);
        }
        public async Task<bool> Update(Route route)
        {
           
            return await _unitOfWork.RouteRepository.Update(route);
        }
        public async Task<bool> Delete(int id)
        { 
            return await _unitOfWork.RouteRepository.Delete(id);
        }
    }
}
