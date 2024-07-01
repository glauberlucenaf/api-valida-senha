
using API.ValidaSenha.Application.Commands;
using API.ValidaSenha.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.ValidaSenha.Controllers
{
    [ApiController]
    [Route("senha")]
    public class ValidaSenhaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValidaSenhaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Valida a senha de acordo com as regras definidas.
        /// </summary>
        /// <param name="command">O comando contendo a senha a ser validada.</param>
        /// <returns>Retorna se a senha é válida ou não.</returns>
        /// <response code="200">Senha válida.</response>
        /// <response code="422">Senha não validada.</response>
        /// <response code="400">Senha não informada.</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValidaSenhaResult))]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ValidaSenhaResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(object))]
        [HttpPost("validacoes")]
        public async Task<IActionResult> ValidaSenha([FromBody] ValidaSenhaCommand command)
        {
            if (string.IsNullOrEmpty(command.senha))
                return BadRequest("O atributo 'senha' deve ser informado");

            var result = await _mediator.Send(command);

            if (result.IsValid)
                return Ok(result);

            return UnprocessableEntity(result);
        }
    }
}
