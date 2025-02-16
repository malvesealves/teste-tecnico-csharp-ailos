namespace Questao5.Application.Commands.Responses
{
    public sealed class CreateMovementResponse
    {
        public int MovementId { get; set; }

        public CreateMovementResponse(int movementId)
        {
            MovementId = movementId;
        }
    }
}
