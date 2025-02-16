using MediatR;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Infrastructure.Database.QueryStore.Requests
{
    public class GetMovementsByAccountRequest : IRequest<GetMovementsByAccountResponse>
    {
        public Guid AccountId { get; set; }

        public GetMovementsByAccountRequest(Guid accountId)
        {
            AccountId = accountId;
        }        
    }
}
