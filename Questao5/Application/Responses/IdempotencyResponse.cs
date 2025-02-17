namespace Questao5.Application.Responses
{
    public class IdempotencyResponse
    {
        public Guid IdempotencyKey { get; set; }
        public string Request { get; set; }
        public string Response { get; set; }

        public IdempotencyResponse(Guid idempotencyKey, string request, string response)
        {
            IdempotencyKey = idempotencyKey;
            Request = request;
            Response = response;
        }        
    }
}
