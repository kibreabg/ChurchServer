using AutoMapper;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Members.Queries
{
    public class GetMemberQuery: IRequest<MemberDto>
    {
        public int Id { get; set; }
    }

    public class GetMemberQueryHandler : IRequestHandler<GetMemberQuery, MemberDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetMemberQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<MemberDto> Handle(GetMemberQuery request, CancellationToken cancellationToken)
        {
            var member = await _repository.GetByIdAsync<Member>(request.Id);
            return _mapper.Map<MemberDto>(member);
        }
    }
}
