
using API.ValidaSenha.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace API.ValidaSenha.Controllers
{
    [ApiController]
    [Route("valida-senha")]
    public class ValidaSenhaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ValidaSenhaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ValidaSenha([FromBody] ValidaSenhaCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
