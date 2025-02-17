using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public sealed class GetIdempotencyRequest : IRequest<GetIdempotencyResponse>
    {        
        public Guid IdempotencyKey { get; set; }

        public GetIdempotencyRequest(Guid idempotencyKey)
        {
            IdempotencyKey = idempotencyKey;
        }
    }
}
