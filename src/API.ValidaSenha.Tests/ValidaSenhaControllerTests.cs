using API.ValidaSenha.Application.Commands;
using API.ValidaSenha.Application.Validators;
using API.ValidaSenha.Controllers;
using API.ValidaSenha.Models;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Runtime.CompilerServices;

namespace API.ValidaSenha.Tests
{
    public class ValidaSenhaControllerTests
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly ValidaSenhaController _controller;

        public ValidaSenhaControllerTests()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new ValidaSenhaController(_mockMediator.Object);
        }

        [Fact]
        public async void SenhaValida_deveRetornarOkComTrue()
        {
            var command = new ValidaSenhaCommand { senha = "SenhaOk@123" };
            var response = new ValidaSenhaResult { IsValid = true, erros = new List<string>() };

            _mockMediator.Setup(x => x.Send(It.IsAny<ValidaSenhaCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var okResult = await _controller.ValidaSenha(command) as OkObjectResult;
            okResult.Should().NotBeNull();

            var result = okResult.Value as ValidaSenhaResult;
            result.Should().NotBeNull();
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public async void SenhaInvalida_deveRetornarOkComFalse()
        {
            var command = new ValidaSenhaCommand { senha = "senha@123" };
            var response = new ValidaSenhaResult { IsValid = false, erros = new List<string>() };

            _mockMediator.Setup(x => x.Send(It.IsAny<ValidaSenhaCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(response);

            var okResult = await _controller.ValidaSenha(command) as OkObjectResult;
            okResult.Should().NotBeNull();

            var result = okResult.Value as ValidaSenhaResult;
            result.Should().NotBeNull();
            result.IsValid.Should().BeFalse();
        }
    }
}