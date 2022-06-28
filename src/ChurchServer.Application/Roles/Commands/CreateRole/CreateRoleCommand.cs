using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Roles.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<(Result, string)>
    {
        public string RoleName { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateRoleCommand, (Result, string)>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<(Result, string)> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.CreateRoleAsync(request.RoleName);
        }
    }
}
