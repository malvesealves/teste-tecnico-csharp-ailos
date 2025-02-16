using MediatR;
using Questao5.Application.Queries.Responses;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Queries.Requests
{
    public sealed class GetIdempotencyRequest : IRequest<GetIdempotencyResponse>
    {
        [Required]
        public Guid IdempotencyKey { get; set; }

        public GetIdempotencyRequest(Guid idempotencyKey)
        {
            IdempotencyKey = idempotencyKey;
        }        
    }
}
