using AutoMapper;
using ChurchServer.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Roles.Queries
{
    public class GetRoleQuery: IRequest<RoleDto>
    {
        public string Id { get; set; }
    }

    public class GetRoleQueryHandler : IRequestHandler<GetRoleQuery, RoleDto>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public GetRoleQueryHandler(IMapper mapper, IIdentityService identityService)
        {
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<RoleDto> Handle(GetRoleQuery request, CancellationToken cancellationToken)
        {
            var Role = await _identityService.GetRoleByIdAsync(request.Id);
            return _mapper.Map<RoleDto>(Role);
        }
    }
}
