namespace Questao5.Infrastructure.Database.CommandStore.Responses
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
