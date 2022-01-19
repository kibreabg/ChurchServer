using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Members.Queries
{
    public class GetMembersQuery : IRequest<List<MemberGridDto>>
    {
    }

    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, List<MemberGridDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetMembersQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<MemberGridDto>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await _repository.ListAsync<Member>();
            return _mapper.Map<List<MemberGridDto>>(members);
        }
    }
}
