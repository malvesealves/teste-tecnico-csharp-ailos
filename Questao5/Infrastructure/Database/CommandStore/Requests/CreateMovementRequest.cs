using MediatR;
using Questao5.Infrastructure.Database.CommandStore.Responses;

namespace Questao5.Infrastructure.Database.CommandStore.Requests
{
    public class CreateMovementRequest : IRequest<CreateMovementResponse>
    {
    }
}
