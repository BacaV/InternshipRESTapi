using System.Collections.Generic;
using System.Threading.Tasks;
using Product.Datalayer.Model;

namespace Product.DataLayer.Repository
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User newUser);
    }
}
