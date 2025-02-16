using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Handlers
{
    public sealed class CreateMovementHandler : IRequestHandler<CreateMovementRequest, CreateMovementResponse>
    {
        public Task<CreateMovementResponse> Handle(CreateMovementRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
