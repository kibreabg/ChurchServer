using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Roles.Commands.AddUserToRole
{
    public class AddUserToRoleCommand : IRequest<Result>
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<AddUserToRoleCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<Result> Handle(AddUserToRoleCommand request, CancellationToken cancellationToken)
        {
            var role = await _identityService.GetRoleByNameAsync(request.RoleName);
            if (role == null)
            {
                return Result.Failure(new string[] { "Role doesn't exist!" });
            }

            var user = await _identityService.GetUserByIdAsync(request.UserId);
            if (user == null)
            {
                return Result.Failure(new string[] { "User doesn't exist!" });
            }

            return await _identityService.AddUserToRole(user, request.RoleName);
        }
    }
}
