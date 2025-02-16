using MediatR;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Infrastructure.Database.Handlers;
using Questao5.Infrastructure.Database.QueryStore.Requests;
using Questao5.Infrastructure.Database.QueryStore.Responses;

namespace Questao5.Application.Handlers
{
    public sealed class GetBalanceHandler : IRequestHandler<GetBalanceRequest, GetBalanceResponse>
    {
        private readonly GetAccountByIdHandler _accountByIdHandler;
        private readonly GetMovementsByAccountHandler _movementsByAccounthandler;        

        public GetBalanceHandler(GetAccountByIdHandler accountByIdHandler, GetMovementsByAccountHandler movementsByAccounthandler)
        {            
            _accountByIdHandler = accountByIdHandler;
            _movementsByAccounthandler = movementsByAccounthandler;
        }

        public async Task<GetBalanceResponse> Handle(GetBalanceRequest request, CancellationToken cancellationToken)
        {
            CancellationTokenSource source = new();
            CancellationToken token = source.Token;

            GetAccountByIdRequest accountByIdRequest = new(request.AccountId);
            GetMovementsByAccountRequest movementsRequest = new(request.AccountId);

            await Task.WhenAll(_accountByIdHandler.Handle(accountByIdRequest, token), _movementsByAccounthandler.Handle(movementsRequest, token));

            GetAccountByIdResponse accountByIdResponse = _accountByIdHandler.Handle(accountByIdRequest, token).Result;

            GetMovementsByAccountResponse movementsResponse = _movementsByAccounthandler.Handle(movementsRequest, token).Result;
                        
            return new GetBalanceResponse()
            {
                Number = accountByIdResponse.Number,
                Name = accountByIdResponse.Name,
                QueryDateTime = DateTimeOffset.UtcNow.UtcDateTime,
                Balance = GetBalance(movementsResponse)
            };
        }

        private static double GetBalance(GetMovementsByAccountResponse response)
        {            
            if (response.CreditMovements.Any() || response.DebitMovements.Any())
                return response.CreditMovements.Sum(m => m.Value) - response.DebitMovements.Sum(m => m.Value);

            return 0.0D;
        }
    }
}
