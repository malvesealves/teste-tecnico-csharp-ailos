using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands.Requests;
using Questao5.Application.Commands.Responses;
using Questao5.Application.Queries.Requests;
using Questao5.Application.Queries.Responses;
using Questao5.Application.Responses;
using Questao5.Domain.Enumerators;
using Questao5.Domain.Language;
using System.Text.Json;

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
        public async Task<IActionResult> Transaction([FromHeader(Name = "Idempotency-Key")] Guid idempotencyKey, [FromBody] CreateTransactionRequest command)
        {
            if (idempotencyKey == Guid.Empty)
                return BadRequest(new ApiResponse<string>(ValidationType.REQUIRED_IDEMPOTENCY, Messages.Transaction_IdempotencyKeyRequired));

            if (!Enum.IsDefined(typeof(TransactionType), command.TransactionType))
                return BadRequest(new ApiResponse<string>(ValidationType.INVALID_TYPE, Messages.Transaction_InvalidType));

            GetIdempotencyResponse idempotencyQueryResponse = await _mediator.Send(new GetIdempotencyRequest(idempotencyKey));

            if (idempotencyQueryResponse is not null)
                return Ok(new ApiResponse<string>(JsonSerializer.Serialize(
                    new IdempotencyResponse(idempotencyKey, idempotencyQueryResponse.Request, idempotencyQueryResponse.Response))
                    , Messages.Transaction_Succeeded));

            GetAccountByIdResponse accountResponse = await _mediator.Send(new GetAccountByIdRequest(command.AccountId));

            if (accountResponse is null)
                return BadRequest(new ApiResponse<string>(ValidationType.INVALID_ACCOUNT, Messages.Transaction_InvalidAccount));

            if (!accountResponse.Active.Value)
                return BadRequest(new ApiResponse<string>(ValidationType.INACTIVE_ACCOUNT, Messages.Transaction_InactiveAccount));

            CreateTransactionResponse transactionResponse = await _mediator.Send(command);

            string requestIdempotencyCommand = JsonSerializer.Serialize(command);

            string responseIdempotencyCommand = transactionResponse.TransactionId.ToString();

            CreateIdempotencyResponse idempotencyCommandResponse = await _mediator.Send(new CreateIdempotencyRequest(
                idempotencyKey, requestIdempotencyCommand, responseIdempotencyCommand));

            if (idempotencyCommandResponse is null)
                return BadRequest(new ApiResponse<string>(ValidationType.INVALID_IDEMPOTENCY, Messages.Transaction_InvalidIdempotency));
            
            return Ok(new ApiResponse<string>(JsonSerializer.Serialize(
                    new IdempotencyResponse(idempotencyCommandResponse.IdempotencyKey, requestIdempotencyCommand, responseIdempotencyCommand))
                    , Messages.Transaction_Succeeded));
        }

        /// <summary>
        /// Serviço para consultar saldo de uma conta corrente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("saldo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Balance(Guid id)
        {
            GetAccountByIdResponse accountResponse = await _mediator.Send(new GetAccountByIdRequest(id));

            if (accountResponse is null)
                return BadRequest(new ApiResponse<string>(ValidationType.INVALID_ACCOUNT, Messages.Balance_InvalidAccount));

            if (!accountResponse.Active.Value)
                return BadRequest(new ApiResponse<string>(ValidationType.INACTIVE_ACCOUNT, Messages.Balance_InactiveAccount));

            GetTransactionsByAccountResponse transactionsResponse = await _mediator.Send(new GetTransactionsByAccountRequest(id));

            if (transactionsResponse is null || (!transactionsResponse.CreditTransactions.Any() || !transactionsResponse.CreditTransactions.Any()))
                return Ok(new ApiResponse<string>(JsonSerializer.Serialize(
                    new BalanceResponse(accountResponse.Number.Value, accountResponse.Name, DateTimeOffset.UtcNow.ToString("d"), 0.0D.ToString("C")))
                    , Messages.Balance_Succeeded));

            double balanceCalculated = transactionsResponse.CreditTransactions.Sum(c => c.Value) - transactionsResponse.DebitTransactions.Sum(d => d.Value);

            return Ok(new ApiResponse<string>(JsonSerializer.Serialize(
                    new BalanceResponse(accountResponse.Number.Value, accountResponse.Name, DateTimeOffset.UtcNow.ToString("d"), balanceCalculated.ToString("C")))
                    , Messages.Balance_Succeeded));
        }
    }
}