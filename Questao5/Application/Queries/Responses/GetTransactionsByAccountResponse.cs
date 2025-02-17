using Questao5.Domain.Entities;

namespace Questao5.Application.Queries.Responses
{
    public sealed record GetTransactionsByAccountResponse(IEnumerable<Transaction> CreditTransactions, IEnumerable<Transaction> DebitTransactions);
}
