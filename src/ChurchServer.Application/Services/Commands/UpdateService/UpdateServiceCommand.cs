using ChurchServer.Application.Common.Exceptions;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Services.Commands.UpdateService
{
    public class UpdateServiceCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        public IRepository _repository { get; set; }
        public IMediator _mediator { get; set; }

        public UpdateServiceCommandHandler(IMediator mediator, IRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<Unit> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var theService = await _repository.GetByIdAsync<Service>(request.Id);

            if (theService == null)
            {
                throw new NotFoundException(nameof(Service), request.Id);
            }

            theService.Name = request.Name;

            await _repository.UpdateAsync(theService);

            return Unit.Value;
        }
    }


}
