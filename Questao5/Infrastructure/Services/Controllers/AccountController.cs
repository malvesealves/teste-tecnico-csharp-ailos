using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    /// <summary>
    /// Controller para lidar com requisições que envolvem conta corrente
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mediator">Injeção do MediatR</param>
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Serviço para processar movimentação de uma conta corrente
        /// </summary>
        /// <returns></returns>
        [HttpPost("movimentacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Movement([FromHeader(Name = "Idempotency-Key")] Guid idempotencyKey, [FromBody] CreateMovementRequest command)
        {
            if (ModelState.IsValid)
            {

            }

            if (idempotencyKey == Guid.Empty)
                return BadRequest("Idempotency-Key header is required.");

            GetIdempotencyRequest idempotencyRequest = new(idempotencyKey);

            Application.Queries.Responses.GetIdempotencyResponse idempotencyResponse = await _mediator.Send(idempotencyRequest);

            if (idempotencyResponse is not null)
                return Ok(new CreateMovementResponse(int.Parse(idempotencyResponse.Response)));

            CreateMovementResponse response = await _mediator.Send(command);

            var createIdempotency = new CreateIdempotencyRequest()
            {
                IdempotencyKey = new Guid(),
                //Request =
            };

            var teste = await _mediator.Send(createIdempotency);

            int id = 0;
            id++;
            return id < 0 ? BadRequest() : Ok(id);
        }

        /// <summary>
        /// Serviço para consultar saldo de uma conta corrente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("saldo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Balance(string id)
        {
            if (ModelState.IsValid)
            {
                GetBalanceRequest request = new(new Guid(id));
                return Ok(await _mediator.Send(request));
            }

            return BadRequest();
        }
    }
}