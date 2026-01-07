using WebAppApi.Database.Enums;

namespace WebAppApi.Dtos.Responses
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string Avatar { get; set; } = string.Empty;
        public RoleEnum Role { get; set; }
    }
}
