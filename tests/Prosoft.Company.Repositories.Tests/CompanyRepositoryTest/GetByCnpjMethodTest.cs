using FluentAssertions;
using Prosoft.Company.Repositories.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace Prosoft.Company.Repositories.Tests.CompanyRepositoryTest;

[Collection("Database")]
public class GetByCnpjMethodTest
{
    private readonly DatabaseFixture _fixture;
    private readonly ITestOutputHelper _output;

    public GetByCnpjMethodTest(DatabaseFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }

    [Theory(DisplayName = "Deve Recuperar Objeto Nulo Quando Receber CNPJ em Branco")]
    [InlineData(null)]
    [InlineData("")]
    public void Should_GetNullObject_WhenRecibeEmptyCNPJ(string cnpj)
    {
        //Arrange
        _fixture.RemoveModel();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.GetByCnpj(cnpj);

        //Asserts
        actual.Should().BeNull();
    }

    [Fact(DisplayName = "Deve Recuperar Objeto Nulo Quando Não Encontrar Registro")]
    public void Should_GetNullObject_WhenRegisterNotFound()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.GetByCnpj(empresa.Cnpj);

        //Asserts
        actual.Should().BeNull();
    }

    [Fact(DisplayName = "Deve Recuperar Objeto Company Quando Encontrar Registro")]
    public void Should_GetCompanyObject_WhenFoundRegister()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        _fixture.AddModel(empresa);
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.GetByCnpj(empresa.Cnpj);

        //Asserts
        actual.Should().NotBeNull();
        actual.Cnpj.Should().BeEquivalentTo(empresa.Cnpj);
        actual.Nome.Should().BeEquivalentTo(empresa.Nome);
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));
    }
}
