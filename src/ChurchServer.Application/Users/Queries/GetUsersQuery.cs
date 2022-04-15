using AutoMapper;
using ChurchServer.Application.Common.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Users.Queries
{
    public class GetUsersQuery : IRequest<List<UserDto>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IIdentityService identityService, IMapper mapper)
        {
            _identityService = identityService;
            _mapper = mapper;
        }
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _identityService.ListUsersAsync();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
