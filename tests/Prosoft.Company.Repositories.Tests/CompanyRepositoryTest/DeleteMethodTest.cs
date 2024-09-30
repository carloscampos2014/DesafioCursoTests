using FluentAssertions;
using Prosoft.Company.Repositories.Tests.Fixtures;
using Xunit;

namespace Prosoft.Company.Repositories.Tests.CompanyRepositoryTest;

[Collection("Database")]
public class DeleteMethodTest
{
    private readonly DatabaseFixture _fixture;

    public DeleteMethodTest(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact(DisplayName = "Não Deve Excluir Quando Tentar Excluir um Registro Inexistente")]
    public void Should_NotDelete_WhenRegisterNotFound()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.Delete(empresa.Id);

        //Asserts
        actual.Should().BeFalse();
    }

    [Fact(DisplayName = "Deve Excluir Registro Quando Encontrar o Registro")]
    public void Should_DeleteRegister_WhenFoundRegister()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        _fixture.AddModel(empresa);
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);
        empresa = repository.GetByCnpj(empresa.Cnpj);

        //Act
        var actual = repository.Delete(empresa.Id);
        var deleted = repository.GetByCnpj(empresa.Cnpj);

        //Asserts
        actual.Should().BeTrue();
        deleted.Should().BeNull();
    }
}
