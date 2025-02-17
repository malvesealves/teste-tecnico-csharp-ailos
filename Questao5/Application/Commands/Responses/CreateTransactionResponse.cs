namespace Questao5.Application.Commands.Responses
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
