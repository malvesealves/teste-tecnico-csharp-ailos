using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Domain.Entities;
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
            string command = @"SELECT chave_idempotencia AS IdempotencyKey, requisicao AS Request, resultado AS Response 
                               FROM idempotencia 
                               WHERE chave_idempotencia = @IdempotencyKey";

            Dictionary<string, object> dictionary = new()
            {
                { "@IdempotencyKey", request.IdempotencyKey}
            };

            DynamicParameters parameters = new(dictionary);

            using SqliteConnection connection = new(_config.Name);

            Idempotency? idempotency = await connection.QueryFirstOrDefaultAsync<Idempotency>(command, parameters);

            if (idempotency is null)
                return null!;

            return new GetIdempotencyResponse()
            {
                IdempotencyKey = request.IdempotencyKey,
                Request = idempotency.Request,
                Response = idempotency.Response
            };            
        }
    }
}
