using API.ValidaSenha.Application.Commands;
using API.ValidaSenha.Application.Validators;
using FluentAssertions;
using Xunit;

namespace API.ValidaSenha.Tests
{
    public class SenhaValidatorTests
    {
        private readonly SenhaValidator _validator;

        public SenhaValidatorTests()
        {
            _validator = new SenhaValidator();
        }

        [Theory]
        [InlineData("SenhaOk@123", true)] //Senha valida
        [InlineData("Senha@1", false)] //Senha menor que 9 dígitos
        [InlineData("Senhaokok", false)] //Senha apenas com letras
        [InlineData("012345678", false)] //Senha apenas com números
        [InlineData("Semcaractere1", false)] //Senha sem caracter especial
        [InlineData("senhaminuscula@1", false)] //Senha sem maiuscula
        [InlineData("SENHAMAIUSCULA!1", false)] //Senha sem minuscula
        [InlineData("SenhaOk@1123", false)] // Senha com números repetidos
        [InlineData("SenhaaOk@123", false)] // Senha com letras repetidas
        [InlineData("Senha Ok@123", false)] // Senha com espaço
        [InlineData("", false)] // Senha em branco
        public void DeveValidarSenhaCorretamente(string senha, bool expected)
        {
            var command = new ValidaSenhaCommand { senha = senha };

            _validator.Validate(command).IsValid.Should().Be(expected);
        }
    }
}
