using WebAppApi.Database.Models;

namespace WebAppApi.Database.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category?> GetById(int id);
        Task<Category?> GetByName(string name);
        Task<IEnumerable<Category>> GetAllAsync(int userId);
        Task<Category> UpdateAsync(Category category);
        Task<bool> DeleteAsync(Category category);
    }
}
