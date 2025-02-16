using MediatR;
using Questao5.Application.Commands.Responses;
using Questao5.Domain.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace Questao5.Application.Commands.Requests
{
    public sealed class CreateMovementRequest : IRequest<CreateMovementResponse>
    {
        [Required]
        public string AccountId { get; set; }

        [Required]
        [EnumDataType(typeof(MovementType), ErrorMessage = "Status inválido.")]
        public MovementType MovementType { get; set; }

        [Required]
        public double Value { get; set; }
    }
}
