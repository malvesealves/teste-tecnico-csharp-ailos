using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;

namespace Questao5.Infrastructure.Services.Controllers
{
    /// <summary>
    /// Controller para lidar com requisi��es que envolvem conta corrente
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mediator">Inje��o do MediatR</param>
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Servi�o para processar movimenta��o de uma conta corrente
        /// </summary>
        /// <returns></returns>
        [HttpPost("movimentacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Movement([FromHeader(Name = "Idempotency-Key")] string idempotencyKey, [FromBody] CreateMovementRequest command)
        {
            if (string.IsNullOrEmpty(idempotencyKey))
                return BadRequest("Idempotency-Key header is required.");

            var teste = _mediator.Send(command);

            int id = 0;
            id++;
            return id < 0 ? BadRequest() : Ok(id);
        }

        /// <summary>
        /// Servi�o para consultar saldo de uma conta corrente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("saldo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Balance(int id)
        {            
            return id < 0 ? BadRequest() : Ok(id);
        }
    }
}