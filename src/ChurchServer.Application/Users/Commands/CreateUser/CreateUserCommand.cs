using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<(Result, string)>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, (Result, string)>
    {
        private readonly IIdentityService _identityService;

        public CreateUserCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }
        public async Task<(Result, string)> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.CreateUserAsync(request.UserName, request.Password, request.Email, request.PhoneNumber);
        }
    }
}
