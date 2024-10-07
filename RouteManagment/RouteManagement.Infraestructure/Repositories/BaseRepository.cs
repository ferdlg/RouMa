using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Data;

namespace RouteManagement.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        protected readonly DbSet<T> _entities;
        public BaseRepository(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
            _entities = appDbContext.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
            return  _entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
           
        }
        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove( entity);
           
        }


    }
}
