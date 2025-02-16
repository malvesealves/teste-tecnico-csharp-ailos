namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class GetAccountByIdRequest
    {
        public Guid AccountId { get; set; }

        public GetAccountByIdRequest(Guid accountId)
        {
            AccountId = accountId;
        }        
    }
}
