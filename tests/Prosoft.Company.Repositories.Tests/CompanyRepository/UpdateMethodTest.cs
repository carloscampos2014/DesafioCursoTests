using FluentAssertions;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Repositories.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace Prosoft.Company.Repositories.Tests.CompanyRepository;

[Collection("Database")]
public class UpdateMethodTest
{
    private readonly DatabaseFixture _fixture;
    private readonly ITestOutputHelper _output;

    public UpdateMethodTest(DatabaseFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }

    [Fact(DisplayName = "Não Deve Atualizar Quando Receber Objeto Nulo")]
    public void Should_NotUpdate_WhenRecibeNullObject()
    {
        //Arrange
        _fixture.RemoveModel();
        CompanyModel empresa = null;
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.Update(empresa);

        //Asserts
        actual.Should().BeFalse();
    }

    [Fact(DisplayName = "Não Deve Atualizar Quando Tentar Atualizar um Registro Inexistente")]
    public void Should_NotUpdate_WhenTryUpdateNotFoundRegister()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act 
        var actual = repository.Update(empresa);

        //Asserts
        actual.Should().BeFalse();
    }

    [Fact(DisplayName = "Deve Lançar uma Exceção Quando Tentar Atualizar Dados Inválidos")]
    public void Should_ThrowException_WhenTryUpdateInvalidData()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        _fixture.AddModel(empresa);
        empresa.Nome = null;
        empresa.Cnpj = null;
        empresa.Endereco = null;
        empresa.Telefone = null;
        empresa.Email = null;
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act & Assert
        var exception = Assert.Throws<Npgsql.PostgresException>(() => repository.Add(empresa));
        exception.Message.Should().Contain("23502: null value in column \"nome\" of relation \"empresas\" violates not-null constraint");
    }

    [Fact(DisplayName = "Deve Atualizar Registro Quando Receber Dados Validos")]
    public void Should_UpdateRegister_WhenRecibeValidData()
    {
        //Arrange
        _fixture.RemoveModel();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);
        var empresa = _fixture.CreateModel();
        _fixture.AddModel(empresa);
        empresa.Nome = "Carlos";
        empresa.Endereco = "AAAA";
        empresa.Email = "aa@aa.com.br";
        empresa.Telefone = "11999999999";
        empresa.Cnpj = "12345678901234";

        //Act
        var actual = repository.Update(empresa);
        var empresaBanco = repository.GetById(empresa.Id) ?? new CompanyModel();

        //Asserts
        actual.Should().BeTrue();
        empresaBanco.Nome.Should().Be(empresa.Nome);
        empresaBanco.Endereco.Should().Be(empresa.Endereco);
        empresaBanco.Email.Should().Be(empresa.Email);
        empresaBanco.Telefone.Should().Be(empresa.Telefone);
        empresaBanco.Cnpj.Should().Be(empresa.Cnpj);
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(empresaBanco));
    }
}
