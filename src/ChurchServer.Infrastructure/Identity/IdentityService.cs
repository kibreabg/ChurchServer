namespace ChurchServer.Infrastructure.Identity
{
    using ChurchServer.Application.Common.Interfaces;
    using ChurchServer.Application.Common.Models;
    using ChurchServer.Core.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class IdentityService : IIdentityService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IUserClaimsPrincipalFactory<User> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService _authorizationService;

        public IdentityService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IUserClaimsPrincipalFactory<User> userClaimsPrincipalFactory,
            IAuthorizationService authorizationService
            )
        {
            _userManager = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService = authorizationService;
            _roleManager = roleManager;
        }
        public async Task<string> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user.UserName;
        }
        public async Task<User> GetUserByIdAsync(string userId)
        {
            return await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
        }
        public async Task<List<User>> ListUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password, string email, string phoneNumber)
        {
            var user = new User
            {
                UserName = userName,
                PasswordHash = password,
                Email = userName,
                PhoneNumber = phoneNumber
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }
        public async Task<Result> UpdateUserAsync(User user)
        {
            var result = await _userManager.UpdateAsync(user);

            return result.ToApplicationResult();
        }
        public async Task<(bool IsValid, string UserId, string UserName)> CheckPasswordAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                return (await _userManager.CheckPasswordAsync(user, password), user.Id, user.UserName);
            }

            return (await Task.FromResult(false), "", userName);
        }
        public async Task<(Result result, string roleId)> CreateRoleAsync(string roleName)
        {
            var role = new Role
            {
                Name = roleName
            };

            var roleExists = await _roleManager.RoleExistsAsync(roleName);

            if (roleExists)
            {
                return (Result.Failure(new string[] { "Role already exists!" }), "");
            }

            var result = await _roleManager.CreateAsync(role);

            return (result.ToApplicationResult(), role.Id);
        }
        public async Task<Result> UpdateRoleAsync(Role role)
        {
            var result = await _roleManager.UpdateAsync(role);

            return result.ToApplicationResult();
        }
        public async Task<Result> DeleteRoleAsync(string roleId)
        {
            var role = _roleManager.Roles.SingleOrDefault(u => u.Id == roleId);

            if (role != null)
            {
                return await DeleteRoleAsync(role);
            }

            return Result.Success();
        }
        public async Task<Result> DeleteRoleAsync(Role role)
        {
            var result = await _roleManager.DeleteAsync(role);

            return result.ToApplicationResult();
        }
        public async Task<List<Role>> ListRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }
        public async Task<Role> GetRoleByNameAsync(string roleName)
        {
            return await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == roleName);
        }
        public async Task<Role> GetRoleByIdAsync(string roleId)
        {
            return await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == roleId);
        }
        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return await _userManager.IsInRoleAsync(user, role);
        }
        public async Task<Result> AddUserToRole(User user, string roleName)
        {
            var result = await _userManager.AddToRoleAsync(user, roleName);

            return result.ToApplicationResult();
        }
        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }
        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            if (user != null)
            {
                return await DeleteUserAsync(user);
            }

            return Result.Success();
        }
        public async Task<Result> DeleteUserAsync(User user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }
        public async Task<List<Claim>> GetAllValidClaimsAsync(User user)
        {
            var _options = new IdentityOptions();

            var claims = new List<Claim>
            {
                new Claim("user_id", user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            // Getting the claims that we have assigned to the user
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            var userRoles = await _userManager.GetRolesAsync(user);

            foreach (var userRole in userRoles)
            {
                var role = await _roleManager.FindByNameAsync(userRole);

                if (role != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));

                    var roleClaims = await _roleManager.GetClaimsAsync(role);
                    foreach (var roleClaim in roleClaims)
                    {
                        claims.Add(roleClaim);
                    }
                }
            }

            return claims;
        }
        public async Task<string> GenerateJwtToken(string userId, string userName, string secret)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);

            var claims = await GetAllValidClaimsAsync(user);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Issuer = "Church Server",
                Audience = "Church Angular App",
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
