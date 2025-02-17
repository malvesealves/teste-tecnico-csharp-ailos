using Dapper;
using MediatR;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Database.Handlers
{
    public class GetAccountByIdHandler : IRequestHandler<GetAccountByIdRequest, GetAccountByIdResponse>
    {
        private readonly DatabaseConfig _config;

        public GetAccountByIdHandler(DatabaseConfig config)
        {
            _config = config;
        }

        public async Task<GetAccountByIdResponse> Handle(GetAccountByIdRequest request, CancellationToken cancellationToken)
        {
            string command = @"SELECT numero AS Number, nome AS Name, ativo AS Active 
                               FROM contacorrente 
                               WHERE idcontacorrente = @AccountId";

            Dictionary<string, object> dictionary = new()
            {
                { "@AccountId", request.AccountId}
            };

            DynamicParameters parameters = new(dictionary);

            using SqliteConnection connection = new(_config.Name);

            return await connection.QueryFirstOrDefaultAsync<GetAccountByIdResponse>(command, parameters);
        }
    }
}
