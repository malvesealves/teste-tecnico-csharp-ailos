using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public sealed class GetTransactionsByAccountRequest : IRequest<GetTransactionsByAccountResponse>
    {        
        public Guid AccountId { get; set; }

        public GetTransactionsByAccountRequest(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
