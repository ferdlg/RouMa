using ManejoRutas.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using RouteManagment.Core.Entities;
using RouteManagment.Server.Data;

namespace ManejoRutas.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        //logic for Crud Methods 

        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //List all Users
        public async Task<IEnumerable<User>> GetUsers()
        {
            var Users = await _appDbContext.Users.ToListAsync();
            return Users;
        }

        //List User by id 
        public async Task<User> GetUser(int id)
        {
            var User = await _appDbContext.Users.FirstOrDefaultAsync(User_x => User_x.UserId == id);
            return User;
        }

        // Create User

        public async Task PostUser(User User)
        {
            _appDbContext.Users.Add(User);
            await _appDbContext.SaveChangesAsync();

        }

        // Update User by id 
        public async Task<bool> UpdateUser(User User)
        {
            var up_User = await GetUser(User.UserId);
            up_User.DocumentNumber = User.DocumentNumber;
            up_User.Password = User.Password;

            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }


        // Remove User by id
        public async Task<bool> DeleteUser(int id)
        {
            var up_User = await GetUser(id);
            _appDbContext.Users.Remove(up_User);
            int rows = await _appDbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
