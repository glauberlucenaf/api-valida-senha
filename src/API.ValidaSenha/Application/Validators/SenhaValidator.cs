using System.Text.RegularExpressions;
using API.ValidaSenha.Application.Commands;
using FluentValidation;

namespace API.ValidaSenha.Application.Validators
{
    public class SenhaValidator : AbstractValidator<ValidaSenhaCommand>
    {
        public SenhaValidator() {
            RuleFor(x => x.senha)
                .MinimumLength(9).WithMessage("A senha deve ser maior que 9 caracteres")
                .Matches(@"[0-9]").WithMessage("A senha deve conter pelo menos um número")
                .Matches(@"[a-z]").WithMessage("A senha deve conter pelo menos uma letra minúscula")
                .Matches(@"[A-Z]").WithMessage("A senha deve conter pelo menos uma letra maiúscula")
                .Matches(@"[!@#$%^&*()\-\+]").WithMessage("A senha deve conter pelo menos um caractere especial (!@#$%^&*()-+)")
                .Must(VerificaCaracteresRepetidos).WithMessage("A senha não pode conter caracteres repetidos")
                .Must(senha => !senha.Any(char.IsWhiteSpace)).WithMessage("A senha não deve conter espaço em branco");
        }

        private bool VerificaCaracteresRepetidos(string senha)
        {
            return senha.Distinct().Count() == senha.Length;
        }
    }
}
