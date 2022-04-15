using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Application.Common.Models;
using ChurchServer.Application.Users.Commands.CreateUser;
using ChurchServer.Application.Users.Commands.DeleteUser;
using ChurchServer.Application.Users.Commands.UpdateUser;
using ChurchServer.Application.Users.Queries;
using ChurchServer.Core.Entities;
using ChurchServer.Infrastructure.Identity;
using ChurchServer.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChurchServer.Web.ApiControllers
{
    public class UsersController : BaseApiController
    {
        private readonly AppSettings _appSettings;
        private readonly IIdentityService _identityService;

        public UsersController(
            IOptions<AppSettings> appSettings,
            IIdentityService identityService)
        {
            _appSettings = appSettings.Value;
            _identityService = identityService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return await Mediator.Send(new GetUsersQuery());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(string id)
        {
            return await Mediator.Send(new GetUserQuery() { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<string>> Create(CreateUserCommand command)
        {
            var result = await Mediator.Send(command);
            if (result.Item1.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Item1.Errors[0]);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Result>> Delete(string id)
        {
            return await Mediator.Send(new DeleteUserCommand { Id = id });
        }

        [HttpPost]
        [Route(nameof(Login))]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginRequestDTO loginRequestDTO)
        {
            var checkPassResult = await Mediator.Send(new LoginUserQuery { Username = loginRequestDTO.Username, Password = loginRequestDTO.Password });

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
