using FluentAssertions;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Repositories.Tests.Fixtures;
using Xunit;

namespace Prosoft.Company.Repositories.Tests.CompanyRepository;

[Collection("Database")]
public class AddMethodTest
{
    private readonly DatabaseFixture _fixture;

    public AddMethodTest(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "Não Deve Adicionar Empresa Quando Receber Objeto Nulo")]
    public void Should_NotAddCompany_WhenRecibeNullObject()
    {
        //Arrange
        _fixture.RemoveModel();
        CompanyModel empresa = null;
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.Add(empresa);

        //Asserts
        actual.Should().BeFalse();
    }

    [Fact(DisplayName = "Deve Lançar uma Exceção Quando Tentar Adicionar Dados Inválidos")]
    public void Should_ThrowException_WhenTryAddingInvalidData()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = new CompanyModel()
        {
            Cnpj = null,
            Email = null,
            Endereco = null,
            Nome = null,
            Telefone = null,
        };
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act & Assert
        var exception = Assert.Throws<Npgsql.PostgresException>(() => repository.Add(empresa));
        exception.Message.Should().Contain("23502: null value in column \"nome\" of relation \"empresas\" violates not-null constraint");
    }

    [Fact(DisplayName = "Deve Lançar uma Exceção Quando Tentar Adicionar CNPJ já Cadastrado")]
    public void Should_ThrowException_WhenTryAddingCNPJHasRegistered()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        _fixture.AddModel(empresa);
        empresa.Id = Guid.NewGuid();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act & Assert
        var exception = Assert.Throws<Npgsql.PostgresException>(() => repository.Add(empresa));
        exception.Message.Should().Contain("23505: duplicate key value violates unique constraint \"empresas_cnpj_key\"");
    }

    [Fact(DisplayName = "Deve Adicionar Registro Quando Receber Dados Validos")]
    public void Should_AddRegister_WhenRecibeValidData()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.Add(empresa);
        var saved = repository.GetByCnpj(empresa.Cnpj) ?? new CompanyModel();

        //Asserts
        actual.Should().BeTrue();
        saved.Nome.Should().Be(empresa.Nome);
        saved.Endereco.Should().Be(empresa.Endereco);
        saved.Telefone.Should().Be(empresa.Telefone);
        saved.Email.Should().Be(empresa.Email);
    }
}
