using AutoMapper;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Services.Queries
{
    public class GetServicesQuery : IRequest<List<ServiceDto>>
    {
    }

    public class GetServicesQueryHandler : IRequestHandler<GetServicesQuery, List<ServiceDto>>
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GetServicesQueryHandler(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ServiceDto>> Handle(GetServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _repository.ListAsync<Service>();
            return _mapper.Map<List<ServiceDto>>(services);
        }
    }
}
