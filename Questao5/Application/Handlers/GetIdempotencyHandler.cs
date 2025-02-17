using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using InfraQueryRequests = Questao5.Infrastructure.Database.QueryStore.Requests;
using InfraQueryResponses = Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Application.Handlers
{
    public class GetIdempotencyHandler : IRequestHandler<GetIdempotencyRequest, GetIdempotencyResponse>
    {
        private readonly IMediator _mediator;

        public GetIdempotencyHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<GetIdempotencyResponse> Handle(GetIdempotencyRequest request, CancellationToken cancellationToken)
        {
            InfraQueryResponses.GetIdempotencyResponse response = await _mediator.Send(new InfraQueryRequests.GetIdempotencyRequest(request.IdempotencyKey), cancellationToken);

            if (response is null)
                return null!;

            return new GetIdempotencyResponse(response.Request, response.Response);
        }
    }
}
