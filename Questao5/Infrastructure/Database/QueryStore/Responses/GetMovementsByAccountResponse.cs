using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.QueryStore.Responses
{
    public class GetMovementsByAccountResponse
    {

        public IEnumerable<Movement> CreditMovements { get; set; } = Enumerable.Empty<Movement>();
        public IEnumerable<Movement> DebitMovements { get; set; } = Enumerable.Empty<Movement>();
    }
}
