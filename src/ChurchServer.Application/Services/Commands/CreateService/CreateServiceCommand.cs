using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Services.Commands.CreateService
{
    public class CreateServiceCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, int>
    {
        public IRepository _repository { get; set; }
        public IMediator _mediator { get; set; }

        public CreateServiceCommandHandler(IMediator mediator, IRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<int> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var newService = new Service
            {
                Name = request.Name
            };

            await _repository.AddAsync(newService);

            return newService.Id;
        }
    }


}
