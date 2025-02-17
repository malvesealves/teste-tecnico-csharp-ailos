using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Handlers
{
    public class GetIdempotencyHandler : IRequestHandler<GetIdempotencyRequest, GetIdempotencyResponse>
    {
        private readonly DatabaseConfig _config;

        public GetIdempotencyHandler(DatabaseConfig config)
        {
            _config = config;
        }

        public async Task<GetIdempotencyResponse> Handle(GetIdempotencyRequest request, CancellationToken cancellationToken)
        {
            string command = @"SELECT requisicao, resultado FROM idempotencia 
                               WHERE chave_idempotencia = @IdempotencyKey";

            Dictionary<string, object> dictionary = new()
            {
                { "@IdempotencyKey", request.IdempotencyKey}
            };

            DynamicParameters parameters = new(dictionary);

            using SqliteConnection connection = new(_config.Name);

            return await connection.QueryFirstOrDefaultAsync<GetIdempotencyResponse>(command, parameters);
        }
    }
}
