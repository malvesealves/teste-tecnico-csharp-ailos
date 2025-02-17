using MediatR;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class CreateIdempotencyRequest : IRequest<CreateIdempotencyResponse>
    {        
        public Guid IdempotencyKey { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }

        public CreateIdempotencyRequest(Guid idempotencyKey, string request, string response)
        {
            IdempotencyKey = idempotencyKey;
            Request = request;
            Response = response;
        }
    }
}
