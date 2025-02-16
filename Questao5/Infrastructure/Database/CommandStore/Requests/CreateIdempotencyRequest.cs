namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class CreateIdempotencyRequest
    {
        public Guid IdempotencyKey { get; set; }

        public string Request { get; set; }

        public string Response { get; set; }
    }
}
