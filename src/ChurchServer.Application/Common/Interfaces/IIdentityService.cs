using ChurchServer.Application.Common.Models;
using System.Threading.Tasks;

namespace ChurchServer.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<(bool IsValid, string UserId, string UserName)> CheckPasswordAsync(string userName, string password);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(string userId);
        string GenerateJwtToken(string userId, string userName, string secret);
    }
}
