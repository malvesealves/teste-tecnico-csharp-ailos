using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class GetTransactionsByAccountRequest : IRequest<GetTransactionsByAccountResponse>
    {
        public Guid AccountId { get; set; }

        public GetTransactionsByAccountRequest(Guid accountId)
        {
            AccountId = accountId;
        }        
    }
}
