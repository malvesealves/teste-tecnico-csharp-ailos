using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Questao5.Infrastructure.Services.Controllers
{
    /// <summary>
    /// Controller para conta corrente
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ContaCorrenteController : ControllerBase
    {      
        private readonly ILogger<ContaCorrenteController> _logger;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger"></param>
        public ContaCorrenteController(ILogger<ContaCorrenteController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("movimentacao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Movimentacao([FromBody] object data)
        {
            _logger.LogInformation("");
            int id = 0;
            id++;
            return id < 0 ? BadRequest() : Ok(id);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("saldo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Saldo(int id)
        {
            _logger.LogInformation("");
            return id < 0 ? BadRequest() : Ok(id);
        }
    }
}