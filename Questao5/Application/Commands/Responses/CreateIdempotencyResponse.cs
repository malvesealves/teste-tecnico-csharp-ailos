namespace Questao5.Application.Commands.Responses
{
    public class CreateIdempotencyResponse
    {
        public Guid IdempotencyKey { get; set; }

        public CreateIdempotencyResponse(Guid idempotencyKey)
        {
            IdempotencyKey = idempotencyKey;
        }        
    }
}
