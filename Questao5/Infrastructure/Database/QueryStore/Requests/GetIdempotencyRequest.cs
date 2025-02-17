using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public sealed record GetIdempotencyRequest(Guid IdempotencyKey) : IRequest<GetIdempotencyResponse>;
}
