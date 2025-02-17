using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using InfraQueryRequests = Questao5.Infrastructure.Database.QueryStore.Requests;
using InfraQueryResponses = Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Application.Handlers
{
    public sealed class GetAccountByIdHandler : IRequestHandler<GetAccountByIdRequest, GetAccountByIdResponse>
    {
        private readonly IMediator _mediator;

        public GetAccountByIdHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetAccountByIdResponse> Handle(GetAccountByIdRequest request, CancellationToken cancellationToken)
        {
            InfraQueryResponses.GetAccountByIdResponse response = await _mediator.Send(new InfraQueryRequests.GetAccountByIdRequest(request.AccountId), cancellationToken);

            if (response is null)
                return null!;

            return new GetAccountByIdResponse(response.Number, response.Name, response.Active);
        }
    }
}
