using MediatR;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class CreateIdempotencyRequest : IRequest<CreateIdempotencyResponse>
    {
        public Guid IdempotencyKey { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }
    }
}
