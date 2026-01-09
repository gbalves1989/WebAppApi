using WebAppApi.Database.Interfaces;
using WebAppApi.Database.Models;
using WebAppApi.Dtos.Requests;
using WebAppApi.Dtos.Responses;
using WebAppApi.Services.Interfaces;
using WebAppApi.Database.Enums;

namespace WebAppApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ApiResponse<UserResponse>> CreateAsync(UserRequest userRequest)
        {
            User? userExists = await _userRepository.GetByEmailAsync(userRequest.Email);

            if (userExists != null)
            {
                return ApiResponse<UserResponse>.Conflict("E-mail já está cadastrado.");
            }

            User newUser = new User
            {
                FullName = userRequest.FullName,
                Email = userRequest.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
            };

            User createdUser = await _userRepository.CreateAsync(newUser);
            
            UserResponse userResponse = new UserResponse
            {
                Id = createdUser.Id,
                FullName = createdUser.FullName,
                Email = createdUser.Email,
                Avatar = createdUser.Avatar,
                Role = createdUser.Role
            };

            return ApiResponse<UserResponse>.Created(userResponse, "Usuário criado com sucesso.");
        }

        public async Task<ApiResponse<bool>> DeleteAsync(string email)
        {
            User? userExists = await _userRepository.GetByEmailAsync(email);
            await _userRepository.DeleteAsync(userExists);
            
            return ApiResponse<bool>.NoContent(true, "Usuário removido com sucesso.");
        }

        public async Task<ApiResponse<UserResponse?>> GetByEmailAsync(string email)
        {
            User? userExists = await _userRepository.GetByEmailAsync(email);

            UserResponse userResponse = new UserResponse
            {
                Id = userExists.Id,
                FullName = userExists.FullName,
                Email = userExists.Email,
                Avatar = userExists.Avatar,
                Role = userExists.Role
            };

            return ApiResponse<UserResponse?>.Ok(userResponse, "Usuário encontrado com sucesso.");
        }

        public async Task<ApiResponse<UserResponse>> UpdateAsync(UserRequest userRequest)
        {
            User? userExists = await _userRepository.GetByEmailAsync(userRequest.Email);

            userExists.FullName = userRequest.FullName;
            userExists.Avatar = userRequest.Avatar;

            User updatedUser = await _userRepository.UpdateAsync(userExists);

            UserResponse userResponse = new UserResponse
            {
                Id = updatedUser.Id,
                FullName = updatedUser.FullName,
                Email = updatedUser.Email,
                Avatar = updatedUser.Avatar,
                Role = updatedUser.Role
            };

            return ApiResponse<UserResponse>.Accept(userResponse, "Usuário atualizado com sucesso.");
        }

        public async Task<ApiResponse<UserResponse>> UpdateRoleAdminAsync(string email)
        {
            User? userExists = await _userRepository.GetByEmailAsync(email);

            userExists.Role = RoleEnum.ADMIN;

            User updatedUser = await _userRepository.UpdateAsync(userExists);

            UserResponse userResponse = new UserResponse
            {
                Id = updatedUser.Id,
                FullName = updatedUser.FullName,
                Email = updatedUser.Email,
                Avatar = updatedUser.Avatar,
                Role = updatedUser.Role
            };

            return ApiResponse<UserResponse>.Accept(userResponse, "Usuário atualizado com sucesso.");
        }

        public async Task<ApiResponse<UserResponse>> UpdateRoleUserAsync(string email)
        {
            User? userExists = await _userRepository.GetByEmailAsync(email);

            userExists.Role = RoleEnum.USER;

            User updatedUser = await _userRepository.UpdateAsync(userExists);

            UserResponse userResponse = new UserResponse
            {
                Id = updatedUser.Id,
                FullName = updatedUser.FullName,
                Email = updatedUser.Email,
                Avatar = updatedUser.Avatar,
                Role = updatedUser.Role
            };

            return ApiResponse<UserResponse>.Accept(userResponse, "Usuário atualizado com sucesso.");
        }
    }
}
