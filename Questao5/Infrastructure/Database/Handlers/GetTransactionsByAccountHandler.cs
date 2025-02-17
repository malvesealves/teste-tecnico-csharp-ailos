using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;
using System.Text;

namespace Questao5.Infrastructure.Database.Handlers
{
    public class GetTransactionsByAccountHandler : IRequestHandler<GetTransactionsByAccountRequest, GetTransactionsByAccountResponse>
    {
        private readonly DatabaseConfig _config;

        public GetTransactionsByAccountHandler(DatabaseConfig config)
        {
            _config = config;
        }

        public async Task<GetTransactionsByAccountResponse> Handle(GetTransactionsByAccountRequest request, CancellationToken cancellationToken)
        {
            StringBuilder baseQuery = new(@"SELECT idmovimento AS TransactionId, idcontacorrente AS AccountId, datamovimento AS TransactionDate, 
                                                   tipomovimento AS TransactionType, valor AS Value 
                                            FROM movimento WHERE idcontacorrente = @AccountId");

            string creditQuery = baseQuery.Append($@" AND tipomovimento = '{(char)TransactionType.Credito}'").ToString();
            string debitQuery = baseQuery.Append($@" AND tipomovimento = '{(char)TransactionType.Debito}'").ToString();

            Dictionary<string, object> dictionary = new()
                {
                    { "@AccountId", request.AccountId}
                };

            DynamicParameters parameters = new(dictionary);

            using SqliteConnection connection = new(_config.Name);

            Task<IEnumerable<Transaction>> creditTransactions = connection.QueryAsync<Transaction>(creditQuery, parameters);
            Task<IEnumerable<Transaction>> debitTransactions = connection.QueryAsync<Transaction>(debitQuery, parameters);

            await Task.WhenAll(creditTransactions, debitTransactions);

            return new GetTransactionsByAccountResponse()
            {
                CreditTransactions = creditTransactions.Result,
                DebitTransactions = debitTransactions.Result
            };
        }
    }
}
