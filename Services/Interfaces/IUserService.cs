using WebAppApi.Dtos.Requests;
using WebAppApi.Dtos.Responses;

namespace WebAppApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse<UserResponse>> CreateAsync(UserRequest userRequest);
        Task<ApiResponse<UserResponse>> UpdateAsync(UserRequest userRequest);
        Task<ApiResponse<UserResponse?>> GetByEmailAsync(string email);
        Task<ApiResponse<bool>> DeleteAsync(string email);
        Task<ApiResponse<UserResponse>> UpdateRoleAdminAsync(string email);
        Task<ApiResponse<UserResponse>> UpdateRoleUserAsync(string email);
    }
}
