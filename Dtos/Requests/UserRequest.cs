using WebAppApi.Database.Enums;

namespace WebAppApi.Dtos.Requests
{
    public class UserRequest
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string? Avatar { get; set; }
        public RoleEnum? Role { get; set; }
    }
}
