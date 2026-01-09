using WebAppApi.Database.Models;

namespace WebAppApi.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }
}
