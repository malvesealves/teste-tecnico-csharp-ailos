using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public sealed class GetTransactionsByAccountResponse
    {
        public IEnumerable<Transaction> CreditTransactions { get; set; } = Enumerable.Empty<Transaction>();
        public IEnumerable<Transaction> DebitTransactions { get; set; } = Enumerable.Empty<Transaction>();
    }
}
