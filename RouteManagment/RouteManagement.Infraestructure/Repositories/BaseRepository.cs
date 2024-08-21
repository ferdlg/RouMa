using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Core.Interfaces;
using RouteManagment.Server.Data;

namespace RouteManagement.Infraestructure.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _appDbContext;
        private DbSet<T> _entities;
        public BaseRepository(AppDbContext appDbContext) 
        { 
            _appDbContext = appDbContext;
            _entities = appDbContext.Set<T>();
        }
        public async Task Add(T entity)
        {
            _entities.Add(entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            _entities.Remove( entity);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
