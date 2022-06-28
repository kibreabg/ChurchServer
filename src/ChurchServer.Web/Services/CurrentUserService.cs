using ChurchServer.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace ChurchServer.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        //JWT user_id ClaimType used to find user Id
        public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("user_id");
    }
}
