using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Domain.Entities;
using InfraQueryRequests = Questao5.Infrastructure.Database.QueryStore.Requests;
using InfraQueryResponses = Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Application.Handlers
{
    public sealed class GetTransactionsByAccountHandler : IRequestHandler<GetTransactionsByAccountRequest, GetTransactionsByAccountResponse>
    {
        private readonly IMediator _mediator;

        public GetTransactionsByAccountHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetTransactionsByAccountResponse> Handle(GetTransactionsByAccountRequest request, CancellationToken cancellationToken)
        {
            InfraQueryResponses.GetTransactionsByAccountResponse response = await _mediator.Send(new InfraQueryRequests.GetTransactionsByAccountRequest(request.AccountId), 
                cancellationToken);

            if (response is null)
                return null!;

            return new GetTransactionsByAccountResponse(response.CreditTransactions, response.DebitTransactions);
        }
    }
}
