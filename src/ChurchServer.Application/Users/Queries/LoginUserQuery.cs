using ChurchServer.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Users.Queries
{
    public class LoginUserQuery : IRequest<LoginResultDTO>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class LoginUserQueryHandler : IRequestHandler<LoginUserQuery, LoginResultDTO>
    {
        private readonly IIdentityService _identityService;
        public LoginUserQueryHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<LoginResultDTO> Handle(LoginUserQuery request, CancellationToken cancellationToken)
        {
            var checkPassResult = await _identityService.CheckPasswordAsync(request.Username, request.Password);

            return new LoginResultDTO
            {
                IsValid = checkPassResult.IsValid,
                UserId = checkPassResult.UserId,
                UserName = checkPassResult.UserName
            };
        }
    }
}
