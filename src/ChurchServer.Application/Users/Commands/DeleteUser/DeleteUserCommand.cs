using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Application.Common.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Result>
    {
        public string Id { get; set; }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public DeleteUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.DeleteUserAsync(request.Id);
        }
    }
}
