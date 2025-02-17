using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using InfraCommandRequests = Questao5.Infrastructure.Database.CommandStore.Requests;
using InfraCommandResponses = Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Application.Handlers
{
    public sealed class CreateIdempotencyHandler : IRequestHandler<CreateIdempotencyRequest, CreateIdempotencyResponse>
    {
        private readonly IMediator _mediator;

        public CreateIdempotencyHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CreateIdempotencyResponse> Handle(CreateIdempotencyRequest request, CancellationToken cancellationToken)
        {
            InfraCommandResponses.CreateIdempotencyResponse response = await _mediator.Send(new InfraCommandRequests.CreateIdempotencyRequest(
                request.IdempotencyKey, request.Request, request.Response)
            , cancellationToken);

            if (response is null)
                return null!;

            return new CreateIdempotencyResponse(response.IdempotencyKey);
        }
    }
}
