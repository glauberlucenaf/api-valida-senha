using API.ValidaSenha.Models;
using MediatR;

namespace API.ValidaSenha.Application.Commands
{
    public class ValidaSenhaCommand : IRequest<ValidaSenhaResult>
    {
        public string senha { get; set; }
    }
}
