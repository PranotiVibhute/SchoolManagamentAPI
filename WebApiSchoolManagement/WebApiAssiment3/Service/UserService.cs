using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebApiAssiment3.Context;
using WebApiAssiment3.Entities;
using WebApiAssiment3.Interface;

namespace WebApiAssiment3.Service
{
    public class UserService : IUser
    {
        private readonly SchoolManagementDbContext _dbContext;

        public UserService(SchoolManagementDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<User>> GetAllUsers()
        {
            return await _dbContext.Users.ToListAsync();
        }
        public async Task<User?> GetUserById(int id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(obj => obj.UserId == id);
        }
        public async Task<User?> AddUsers(User user)
        {
            var obj = new User()
            {
                UserName = user.UserName,
                PasswordHash = user.PasswordHash,
                Role = user.Role,
            };
            _dbContext.Users.Add(obj);
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? obj : null;
        }
        public async Task<User?> UpdateUser(int id, User updateUser)
        {
            var obj = await _dbContext.Users.FirstOrDefaultAsync(u => u.UserId == id);
            if (obj != null)
            {
                obj.UserName = updateUser.UserName;
                obj.PasswordHash = updateUser.PasswordHash;
                obj.Role = updateUser.Role;
            }
            
            var result = await _dbContext.SaveChangesAsync();
            return result >= 0 ? obj : null;
        }
        public async Task<bool>DeleteUserById(int id)
        {
            var obj= await _dbContext.Users.FirstOrDefaultAsync(u=>u.UserId== id);
            if(obj != null)
            {
                _dbContext.Users.Remove(obj);
                var result= await _dbContext.SaveChangesAsync();
                return result >= 0 ;
            }
            return false;
        }
    }
}
