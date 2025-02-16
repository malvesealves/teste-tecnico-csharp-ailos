using MediatR;
using Questao5.Application.Queries.Responses;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Queries.Requests
{
    public sealed class GetBalanceRequest : IRequest<GetBalanceResponse>
    {
        [Required]
        public Guid AccountId { get; set; }    

        public GetBalanceRequest(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
