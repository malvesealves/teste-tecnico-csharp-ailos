using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using InfraCommandRequests = Questao5.Infrastructure.Database.CommandStore.Requests;
using InfraCommandResponses = Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Application.Handlers
{
    public sealed class CreateTransactionHandler : IRequestHandler<CreateTransactionRequest, CreateTransactionResponse>
    {
        private readonly IMediator _mediator;

        public CreateTransactionHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<CreateTransactionResponse> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            InfraCommandResponses.CreateTransactionResponse response = await _mediator.Send(new InfraCommandRequests.CreateTransactionRequest(
                request.AccountId, request.TransactionType, request.Value)
            , cancellationToken);

            if (response is null)
                return null!;

            return new CreateTransactionResponse(response.TransactionId);
        }
    }
}
