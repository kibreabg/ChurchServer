using AutoMapper;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Services.Queries
{
    public class GetServiceQuery : IRequest<ServiceDto>
    {
        public int Id { get; set; }
    }

    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, ServiceDto>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetServiceQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ServiceDto> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var service = await _repository.GetByIdAsync<Service>(request.Id);
            return _mapper.Map<ServiceDto>(service);
        }
    }
}
