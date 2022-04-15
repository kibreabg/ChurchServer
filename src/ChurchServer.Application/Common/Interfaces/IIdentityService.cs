using ChurchServer.Application.Common.Models;
using ChurchServer.Application.Users.Queries;
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
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, string email, string phoneNumber);
        Task<Result> UpdateUserAsync(User user);
        Task<Result> DeleteUserAsync(string userId);
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}
