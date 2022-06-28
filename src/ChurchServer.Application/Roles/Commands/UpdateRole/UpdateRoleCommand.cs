using ChurchServer.Application.Common.Exceptions;
using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Roles.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest
    {
        public string Id { get; set; }
        public string RoleName { get; set; }
    }

    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleCommand>
    {
        private readonly IIdentityService _identityService;

        public UpdateRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Unit> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
        {
            var theRole = await _identityService.GetRoleByIdAsync(request.Id);

            if (theRole == null)
            {
                throw new NotFoundException(nameof(Role), request.Id);
            }

            theRole.Name = request.RoleName;

            await _identityService.UpdateRoleAsync(theRole);

            return Unit.Value;

        }
    }
}
