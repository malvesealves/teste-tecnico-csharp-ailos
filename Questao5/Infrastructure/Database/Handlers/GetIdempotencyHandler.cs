using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Handlers
{
    public class GetIdempotencyHandler
    {
        private readonly DatabaseConfig _config;

        public GetIdempotencyHandler(DatabaseConfig config)
        {
            _config = config;
        }

        public async Task<GetIdempotencyResponse> Handle(GetIdempotencyRequest request, CancellationToken cancellationToken)
        {
            string command = "INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) OUTPUT INSERTED.chave_idempotencia VALUES (@IdempotencyKey, @Request, @Response)";

            using SqliteConnection connection = new(_config.Name);

            await connection.ExecuteAsync(command, request);

            // TODO:
            return new GetIdempotencyResponse();
        }
    }
}
