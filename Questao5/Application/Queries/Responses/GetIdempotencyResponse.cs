using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Queries.Responses
{
    public class GetIdempotencyResponse
    {
        public Guid IdempotencyKey { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }
    }
}
