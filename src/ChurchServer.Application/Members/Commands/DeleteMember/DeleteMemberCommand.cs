using ChurchServer.Application.Common.Exceptions;
using ChurchServer.Core.Entities;
using ChurchServer.SharedKernel.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ChurchServer.Application.Members.Commands.DeleteMember
{
    public class DeleteMemberCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand>
    {
        public IRepository _repository { get; set; }

        public DeleteMemberCommandHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
        {
            var theMember = await _repository.GetByIdAsync<Member>(request.Id);

            if (theMember == null)
            {
                throw new NotFoundException(nameof(Member), request.Id);
            }

            await _repository.DeleteAsync(theMember);

            return Unit.Value;
        }
    }
}
