using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Database.CommandStore.Requests;
using Questao5.Infrastructure.Database.CommandStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Handlers
{
    public class CreateIdempotencyHandler
    {
        private readonly DatabaseConfig _config;

        public CreateIdempotencyHandler(DatabaseConfig config)
        {
            _config = config;
        }

        public async Task<CreateIdempotencyResponse> HandleAsync(CreateIdempotencyRequest request)
        {
            string command = "INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) OUTPUT INSERTED.chave_idempotencia VALUES (@IdempotencyKey, @Request, @Response)";

            using SqliteConnection connection = new(_config.Name);
            
            await connection.ExecuteAsync(command, request);

            // TODO:
            return new CreateIdempotencyResponse(new Guid());
        }
    }
}
