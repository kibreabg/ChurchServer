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
    public class GetRolesQuery : IRequest<List<RoleDto>>
    {
    }

    public class GetRolesQueryHandler : IRequestHandler<GetRolesQuery, List<RoleDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public GetRolesQueryHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _identityService.ListRolesAsync();
            return _mapper.Map<List<RoleDto>>(roles);
        }
    }
}
