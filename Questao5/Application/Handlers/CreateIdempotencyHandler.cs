using MediatR;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;

namespace Questao5.Application.Handlers
{
    public class CreateIdempotencyHandler : IRequestHandler<CreateIdempotencyRequest, CreateIdempotencyResponse>
    {
        private readonly Infrastructure.Database.CommandStore.Handlers.CreateIdempotencyHandler _commandHandler;

        public CreateIdempotencyHandler(Infrastructure.Database.CommandStore.Handlers.CreateIdempotencyHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public Task<CreateIdempotencyResponse> Handle(CreateIdempotencyRequest request, CancellationToken cancellationToken)
        {           
            throw new NotImplementedException();
        }
    }
}
