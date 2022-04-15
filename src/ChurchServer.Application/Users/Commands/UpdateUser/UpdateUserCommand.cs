using ChurchServer.Application.Common.Exceptions;
using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IIdentityService _identityService;

        public UpdateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var theUser = await _identityService.GetUserByIdAsync(request.Id);

            if (theUser == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            theUser.UserName = request.UserName;
            theUser.Email = request.Email;
            theUser.PhoneNumber = request.PhoneNumber;

            await _identityService.UpdateUserAsync(theUser);

            return Unit.Value;

        }
    }
}
