using Bogus;
using FluentAssertions;
using System.Net;
using UsersApi.Tests.Helpers;
using UsersAPI.Application.Dtos.Requests;
using UsersAPI.Application.Dtos.Responses;

namespace UsersApi.Tests;

public class UsersTests
{
    [Fact]
    public async Task Users_Post_Returns_Created()
    {

        //dados enviados para a requisição
        var faker = new Faker("pt_BR");

        var request = new UserAddRequestDto
        {
            Nome = faker.Person.FullName,
            Email = faker.Internet.Email(),
            Password = "@Teste123",
            PasswordConfirm = "@Teste123",
        };

        //serializando os dados da requisição
        var content = TestHelper.CreateContent(request);

        //fazendo a requisição POST para api
        var result = await TestHelper.CreateClient.PostAsync("/api/users", content);

        //capiturado e verificando o status da responta
        result.StatusCode.Should().Be(HttpStatusCode.Created);

        //capiturando e verificando o conteudo da responta
        var repsonse = TestHelper.ReadResponse<UserResponseDto>(result);
        repsonse.Id.Should().NotBeEmpty();
        repsonse.Nome.Should().Be(request.Nome);
        repsonse.Email.Should().Be(request.Email);
        repsonse.DataCadastro.Should().NotBeNull();
    }

    [Fact(Skip = "Não implementado")]
    public void Users_Post_Returns_BadRequest()
    {

    }
    [Fact(Skip = "Não implementado")]
    public void Users_PUt_Returns_Ok()
    {

    }
    [Fact(Skip = "Não implementado")]
    public void Users_Delete_Returns_Ok()
    {

    }
}