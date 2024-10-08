using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Exceptions;
using RouteManagment.Core.Interfaces;

namespace RouteManagment.Core.Services
{
    public class TransportService : ITransportService
    {
        private readonly ITransportUnitOfWork _unitOfwork;
        public TransportService(ITransportUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        //validations 
        private async Task ValidationTransportExist(string plate)
        {
            var transport = await _unitOfwork.TransportRepository.GetTransport(plate);
            if (transport == null)
            {
                throw new BussinesExceptions(ErrorCode.NotFound, message: $"Transport with plate{plate} not found.");
            }
        }
        private async Task ValidationTransportCapacity(string plate, int numberPassengers)
        {
            await ValidationTransportExist(plate);
            var transport = await _unitOfwork.TransportRepository.GetTransport(plate);
            var capacity = transport.Capacity;
            var minCapacity = (capacity / 2);


            if (numberPassengers > capacity)
            {
                throw new BussinesExceptions(ErrorCode.Forbidden, message: "The number of passengers exceeds the capacity.");
            }
            if (numberPassengers < minCapacity)
            {
                throw new BussinesExceptions(ErrorCode.Forbidden, message: "The number of passengers does not meet the minimum capacity");
            }
        }


        //
        public IEnumerable<Transport> GetTransports()
        {
            return _unitOfwork.TransportRepository.GetTransports();
        }

        public async Task<Transport> GetTransport(string plate)
        {
            return await _unitOfwork.TransportRepository.GetTransport(plate);
        }

        public async Task InsertTransport(Transport Transport)
        {
            await _unitOfwork.TransportRepository.AddTransport(Transport);
            Console.WriteLine("Transport added successfully.");
            await _unitOfwork.SaveChangesAsync();
        }

        public async Task<bool> Update(Transport transport)
        {
            _unitOfwork.TransportRepository.UpdateTransport(transport);
            await _unitOfwork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(string plate)
        {
            try
            {
                var transport = await _unitOfwork.TransportRepository.GetTransport(plate);

                if (transport == null)
                {
                    throw new BussinesExceptions(ErrorCode.NotFound, $"El transporte con placa {plate} no se encontró.");
                }
                await _unitOfwork.TransportRepository.DeleteTransport(plate);
                await _unitOfwork.SaveChangesAsync();

                Console.WriteLine("Transporte eliminado correctamente.");
                return true;
            }
            catch (BussinesExceptions ex)
            {
                Console.WriteLine($"Error de negocio: {ex.ErrorCode} - {ex.ErrorMessage}");
                return false;
            }
            catch (DbUpdateException dbEx)
            {
                Console.WriteLine($"Error en la actualización de la base de datos: {dbEx.InnerException?.Message}");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }


    public class BaseServiceT<T> : IServiceT<T> where T : BaseEntity
    {
        private readonly ITransportUnitOfWork _unitOfWork;
        public BaseServiceT(ITransportUnitOfWork iunitOfWork)
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
            await _unitOfWork.SaveChangesAsync();
            return entity;
        }
        public async Task<T> Delete(int id)
        {
            var entity = await _unitOfWork.GetRepository<T>().GetById(id);
            if (entity != null)
            {

                await _unitOfWork.GetRepository<T>().Delete(id);
                await _unitOfWork.SaveChangesAsync();
            }

            return entity;
        }


    }
}



