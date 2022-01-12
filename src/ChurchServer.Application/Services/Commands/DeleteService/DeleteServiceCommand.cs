using ChurchServer.Application.Common.Exceptions;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Services.Commands.DeleteService
{
    public class DeleteServiceCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        public IRepository _repository { get; set; }
        public IMediator _mediator { get; set; }

        public DeleteServiceCommandHandler(IMediator mediator, IRepository repository)
        {
            _mediator = mediator;
            _repository = repository;
        }
        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var theService = await _repository.GetByIdAsync<Service>(request.Id);

            if (theService == null)
            {
                throw new NotFoundException(nameof(Service), request.Id);
            }

            await _repository.DeleteAsync(theService);

            return Unit.Value;
        }
    }
}
