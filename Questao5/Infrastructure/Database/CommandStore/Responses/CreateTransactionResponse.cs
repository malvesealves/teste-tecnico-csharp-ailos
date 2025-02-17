namespace Questao5.Infrastructure.Database.CommandStore.Responses
{
    public sealed class CreateTransactionResponse
    {
        public Guid TransactionId { get; set; }

        public CreateTransactionResponse(Guid transactionId)
        {
            TransactionId = transactionId;
        }
    }
}
