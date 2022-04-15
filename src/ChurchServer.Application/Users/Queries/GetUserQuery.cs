using AutoMapper;
using ChurchServer.Application.Common.Interfaces;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Users.Queries
{
    public class GetUserQuery : IRequest<UserDto>
    {
        public string Id { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, UserDto>
    {
        private readonly IIdentityService _identityService;
        private readonly IMapper _mapper;

        public GetUserQueryHandler(IMapper mapper, IIdentityService identityService)
        {
            _mapper = mapper;
            _identityService = identityService;
        }

        public async Task<UserDto> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _identityService.GetUserByIdAsync(request.Id);
            return _mapper.Map<UserDto>(user);
        }
    }
}
