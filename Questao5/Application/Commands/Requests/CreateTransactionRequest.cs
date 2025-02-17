using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Language;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Commands.Requests
{
    public sealed class CreateTransactionRequest : IRequest<CreateTransactionResponse>
    {
        [Required]
        public Guid AccountId { get; set; }

        [Required]
        public string TransactionType { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = Messages.Transaction_InvalidValue)]
        public double Value { get; set; }

        public CreateTransactionRequest(Guid accountId, string transactionType, double value)
        {
            AccountId = accountId;
            TransactionType = transactionType;
            Value = value;
        }
    }
}
