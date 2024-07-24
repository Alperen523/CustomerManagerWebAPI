using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerManagerWebApiByAlp.Models;

namespace CustomerManagerWebApiByAlp.Repositories
{
    public interface IUserRepository
    {
        Task<User> ValidateUser(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(int id);
    }
}
