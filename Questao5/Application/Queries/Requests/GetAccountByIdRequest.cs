using MediatR;
using Questao5.Application.Queries.Responses;

namespace Questao5.Application.Queries.Requests
{
    public sealed class GetAccountByIdRequest : IRequest<GetAccountByIdResponse>
    {
        public Guid AccountId { get; set; }

        public GetAccountByIdRequest(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
