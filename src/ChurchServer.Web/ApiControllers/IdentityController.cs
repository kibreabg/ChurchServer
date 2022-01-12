using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Infrastructure.Identity;
using ChurchServer.Web.ApiModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace ChurchServer.Web.ApiControllers
{
    public class IdentityController : BaseApiController
    {
        private readonly AppSettings _appSettings;
        private readonly IIdentityService _identityService;

        public IdentityController(
            IOptions<AppSettings> appSettings,
            IIdentityService identityService)
        {
            _appSettings = appSettings.Value;
            _identityService = identityService;
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<ActionResult> Register(RegisterUserDTO registerUserDTO)
        {
            var user = new User
            {
                Email = registerUserDTO.Email,
                UserName = registerUserDTO.Username,
                PasswordHash = registerUserDTO.Password

            };
            var result = await _identityService.CreateUserAsync(user.UserName, user.PasswordHash);
            if (result.Result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(result.Result.Errors);
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            var checkPassResult = await _identityService.CheckPasswordAsync(loginRequestDTO.Username, loginRequestDTO.Password);

            if (!checkPassResult.IsValid)
            {
                return Unauthorized();
            }

            var token = _identityService.GenerateJwtToken(
                checkPassResult.UserId,
                checkPassResult.UserName,
                _appSettings.Secret);

            return new LoginResponseDTO
            {
                Token = token
            };
        }
    }
}
