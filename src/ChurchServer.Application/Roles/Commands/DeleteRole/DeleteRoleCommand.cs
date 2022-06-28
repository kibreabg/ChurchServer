using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Roles.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<Result>
    {  
        public string Id { get; set; }
    }

    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, Result>
    {
        private readonly IIdentityService _identityService;

        public DeleteRoleCommandHandler(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public async Task<Result> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            return await _identityService.DeleteRoleAsync(request.Id);
        }
    }


}
