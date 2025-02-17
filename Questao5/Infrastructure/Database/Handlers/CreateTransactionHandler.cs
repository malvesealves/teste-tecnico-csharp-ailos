using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Enumerators;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Handlers
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionRequest, CreateTransactionResponse>
    {
        private readonly DatabaseConfig _config;

        public CreateTransactionHandler(DatabaseConfig config)
        {
            _config = config;
        }

        public async Task<CreateTransactionResponse> Handle(CreateTransactionRequest request, CancellationToken cancellationToken)
        {
            string command = @"INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor)
                                              VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor)";

            Dictionary<string, object> dictionary = new()
            {
                { "@IdMovimento", Guid.NewGuid() },
                { "@IdContaCorrente", request.AccountId },
                { "@DataMovimento", DateTimeOffset.UtcNow.ToString("d") },
                { "@TipoMovimento", request.TransactionType },
                { "@Valor", request.Value }
            };

            DynamicParameters parameters = new(dictionary);

            using SqliteConnection connection = new(_config.Name);

            return new CreateTransactionResponse((Guid)await connection.ExecuteScalarAsync(command, parameters));
        }
    }
}
