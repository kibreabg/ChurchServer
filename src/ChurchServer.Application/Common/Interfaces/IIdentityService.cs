using ChurchServer.Application.Common.Models;
using ChurchServer.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchServer.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<User> GetUserByIdAsync(string userId);
        Task<List<User>> ListUsersAsync();
        Task<(bool IsValid, string UserId, string UserName)> CheckPasswordAsync(string userName, string password);
        Task<(Result result, string roleId)> CreateRoleAsync(string roleName);
        Task<Result> UpdateRoleAsync(Role role);
        Task<Result> DeleteRoleAsync(string roleId);
        Task<List<Role>> ListRolesAsync();
        Task<Result> AddUserToRole(User user, string roleName);
        Task<Role> GetRoleByNameAsync(string roleName);
        Task<Role> GetRoleByIdAsync(string roleId);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, string email, string phoneNumber);
        Task<Result> UpdateUserAsync(User user);
        Task<Result> DeleteUserAsync(string userId);
        Task<string> GenerateJwtToken(string userId, string userName, string secret);
    }
}
