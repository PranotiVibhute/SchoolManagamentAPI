using WebApiAssiment3.Entities;

namespace WebApiAssiment3.Interface
{
    public interface IUser
    {
        Task<List<User>> GetAllUsers();
        Task<User?>GetUserById(int id);
        Task<User?> AddUsers(User user);
        Task<User?> UpdateUser(int id,User user);
        Task<bool> DeleteUserById(int id);
    }
}
