namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public sealed class GetIdempotencyResponse
    {
        public Guid IdempotencyKey { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }  
    }
}
