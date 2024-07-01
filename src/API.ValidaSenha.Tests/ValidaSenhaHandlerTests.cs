using API.ValidaSenha.Application.Commands;
using API.ValidaSenha.Application.Handlers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.ValidaSenha.Tests
{
    public class ValidaSenhaHandlerTests
    {
        private readonly ValidaSenhaHandler _handler;

        public ValidaSenhaHandlerTests()
        {
             _handler = new ValidaSenhaHandler();
        }

        [Theory]
        [InlineData("SenhaOk@123")] //Senha valida
        public async Task DeveValidarOk(string senha)
        {
            var command = new ValidaSenhaCommand { senha = senha };

            var result = await _handler.Handle(command, CancellationToken.None);

            result.IsValid.Should().BeTrue();
            result.erros.Count.Should().Be(0);
        }

        [Theory]
        [InlineData("Senha@1")] //Senha menor que 9 dígitos
        [InlineData("Senhaokok")] //Senha apenas com letras
        [InlineData("012345678")] //Senha apenas com números
        [InlineData("Semcaractere1")] //Senha sem caracter especial
        [InlineData("senhaminuscula@1")] //Senha sem maiuscula
        [InlineData("SENHAMAIUSCULA!1")] //Senha sem minuscula
        [InlineData("SenhaOk@1123")] // Senha com números repetidos
        [InlineData("SenhaaOk@123")] // Senha com letras repetidas
        [InlineData("Senha Ok@123")] // Senha com espaço
        [InlineData("")] // Senha em branco
        public async Task DeveValidarNOk(string senha)
        {
            var command = new ValidaSenhaCommand { senha = senha };

            var result = await _handler.Handle(command, CancellationToken.None);

            result.IsValid.Should().BeFalse();
            result.erros.Count.Should().NotBe(0);
        }

    }
}
