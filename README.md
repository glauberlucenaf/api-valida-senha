# :key: API valida senha
API responsável por receber uma senha (string) e efetuar a validação a partir de algumas regras.

## :pushpin: Objetivo
O objeto dessa API é receber uma senha e, ao efetuar algumas validações, constatar se a mesma está integra.
As regras de validação são:

 - A senha deve conter 9 caracteres ou mais;
 - A senha deve possuir ao menos uma letra minúscula;
 - A senha deve possuir ao menos uma letra maiúscula;
 - A senha deve possuir ao menos um número;
 - A senha deve possuir ao menos um caractere especial (!@#$%^&*()-+);
 - A senha não deve possuir números ou letras repetidas (ex : aa, 11);
 - A senha não deve possuir espaços em branco.

## :open_file_folder: Estrutura do projeto

:file_folder: API.ValidaSenha: Contém a aplicação (regras de negócio, models, validators, etc)
:file_folder: API.ValidaSenha.Tests: Contém os testes


## :spiral_notepad: Requisitos

[.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)


## :computer: Configuração de ambiente

1. Clone o repositório
>     git clone https://github.com/glauberlucena/api-valida-senha.git
>     cd api-valida-senha

2. Execute o projeto
>     dotnet restore
>     dotnet run

4. Abra no navegador a rota: http://localhost:8080/swagger/index.html

## POST /valida-senha
### Request
```json
{
  "senha": "string"
}
```
### Responses
- False
```json
{
  "isValid": false,
  "erros": [
    "A senha deve ser maior que 9 caracteres",
    "A senha deve conter pelo menos um número",
    "A senha deve conter pelo menos uma letra minúscula",
    "A senha deve conter pelo menos uma letra maiúscula",
    "A senha deve conter pelo menos um caractere especial (!@#$%^&*()-+)",
    "A senha não pode conter caracteres repetidos",
    "A senha não deve conter espaço em branco"
  ]
}
```
- True
```json
{
  "isValid": true,
  "erros": []
}
```
