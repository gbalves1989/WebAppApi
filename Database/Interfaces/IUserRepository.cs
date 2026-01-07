using WebAppApi.Database.Models;

namespace WebAppApi.Database.Interfaces
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task<User?> GetByEmailAsync(string email);
        Task<IEnumerable<User?>> GetAllAsync(int id);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(User user);
    }
}
