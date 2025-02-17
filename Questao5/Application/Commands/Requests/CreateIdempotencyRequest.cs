using MediatR;
using Questao5.Application.Commands.Responses;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Commands.Requests
{
    public class CreateIdempotencyRequest : IRequest<CreateIdempotencyResponse>
    {
        [Required]
        public Guid IdempotencyKey { get; set; }

        [Required]
        public string Request { get; set; }

        [Required]
        public string Response { get; set; }

        public CreateIdempotencyRequest(Guid idempotencyKey, string request, string response)
        {
            IdempotencyKey = idempotencyKey;
            Request = request;
            Response = response;
        }
    }
}
