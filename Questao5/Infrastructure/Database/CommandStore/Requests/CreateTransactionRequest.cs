using MediatR;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class CreateTransactionRequest : IRequest<CreateTransactionResponse>
    {        
        public Guid AccountId { get; set; }

        public string TransactionType { get; set; }

        public double Value { get; set; }

        public CreateTransactionRequest(Guid accountId, string transactionType, double value)
        {
            AccountId = accountId;
            TransactionType = transactionType;
            Value = value;
        }
    }
}
