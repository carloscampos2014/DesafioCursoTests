using FluentAssertions;
using Prosoft.Company.Repositories.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace Prosoft.Company.Repositories.Tests.CompanyRepository;

[Collection("Database")]
public class GetByIdMethodTest
{
    private readonly DatabaseFixture _fixture;
    private readonly ITestOutputHelper _output;

    public GetByIdMethodTest(DatabaseFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }

    [Fact(DisplayName = "Deve Recuperar Objeto Nulo Quando Não Encontrar Registro")]
    public void Should_GetNullObject_WhenRegisterNotFound()
    {
        //Arrange
        _fixture.RemoveModel();
        var empresa = _fixture.CreateModel();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.GetById(empresa.Id);

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
        var actual = repository.GetById(empresa.Id);

        //Asserts
        actual.Should().NotBeNull();
        actual.Cnpj.Should().BeEquivalentTo(empresa.Cnpj);
        actual.Nome.Should().BeEquivalentTo(empresa.Nome);
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));
    }
}
