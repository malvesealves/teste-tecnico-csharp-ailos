using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;
using System.Text;

namespace Questao5.Infrastructure.Database.Handlers
{
    public class GetMovementsByAccountHandler
    {
        private readonly DatabaseConfig _config;

        public GetMovementsByAccountHandler(DatabaseConfig config)
        {
            _config = config;
        }

        public async Task<GetMovementsByAccountResponse> Handle(GetMovementsByAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                StringBuilder baseQuery = new(@"SELECT idmovimento AS MovementId, idcontacorrente AS AccountId, datamovimento AS MovementDate, " +
                "tipomovimento AS MovementType, valor AS Value " +
                "FROM movimento WHERE idcontacorrente = @AccountId");

                string creditQuery = baseQuery.Append($@" AND tipomovimento = '{(char)MovementType.Credito}'").ToString();
                string debitQuery = baseQuery.Append($@" AND tipomovimento = '{(char)MovementType.Debito}'").ToString();

                Dictionary<string, object> dictionary = new()
                {
                    { "@AccountId", request.AccountId}
                };

                DynamicParameters parameters = new(dictionary);

                using SqliteConnection connection = new(_config.Name);


                Task<IEnumerable<Movement>> creditMovements = connection.QueryAsync<Movement>(creditQuery, parameters);
                Task<IEnumerable<Movement>> debitMovements = connection.QueryAsync<Movement>(debitQuery, parameters);

                await Task.WhenAll(creditMovements, debitMovements);

                return new GetMovementsByAccountResponse()
                {
                    CreditMovements = creditMovements.Result,
                    DebitMovements = debitMovements.Result
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
