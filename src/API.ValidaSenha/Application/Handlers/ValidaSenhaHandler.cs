using API.ValidaSenha.Application.Commands;
using API.ValidaSenha.Application.Validators;
using API.ValidaSenha.Models;
using MediatR;

namespace API.ValidaSenha.Application.Handlers
{
    public class ValidaSenhaHandler : IRequestHandler<ValidaSenhaCommand, ValidaSenhaResult>
    {
        public Task<ValidaSenhaResult> Handle(ValidaSenhaCommand command, CancellationToken cancellationToken)
        {
            var validator = new SenhaValidator().Validate(command);

            var result = new ValidaSenhaResult() 
            { 
                IsValid = validator.IsValid,  
                erros = new List<string>()
            };
            
            if (!validator.IsValid)
            {
                foreach (var error in validator.Errors)
                {
                    result.erros.Add(error.ErrorMessage);
                }
            }

            return Task.FromResult(result);
        }
    }
}
