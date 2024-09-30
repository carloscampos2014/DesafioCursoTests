using FluentAssertions;
using Prosoft.Company.Repositories.Tests.Fixtures;
using Xunit;
using Xunit.Abstractions;

namespace Prosoft.Company.Repositories.Tests.CompanyRepository;

[Collection("Database")]
public class GetAllMethodTest
{
    private readonly ITestOutputHelper _output;
    private readonly DatabaseFixture _fixture;

    public GetAllMethodTest(DatabaseFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        _output = output;
    }

    [Fact(DisplayName = "Deve Recuperar Lista Vazia Quando Não Existir Registros")]
    public void Should_GetListEmpty_WhenNotHaveRegister()
    {
        //Arrange
        _fixture.RemoveModel();
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.GetAll();

        //Asserts
        actual.Any().Should().BeFalse();
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));
    }

    [Fact(DisplayName = "Deve Recuperar Lista Preenchida Quando Existir Registros")]
    public void Should_GetList_WhenHaveRegister()
    {
        //Arrange
        _fixture.RemoveModel();
        var model = _fixture.CreateModel();
        _fixture.AddModel(model);
        var repository = new Repositories.CompanyRepository(_fixture.ConnectionFactory);

        //Act
        var actual = repository.GetAll();

        //Asserts
        actual.Any().Should().BeTrue();
        actual.Count().Should().Be(1);
        actual.FirstOrDefault().Should().NotBeNull();
        actual.FirstOrDefault().Nome.Should().BeEquivalentTo(model.Nome);
        actual.FirstOrDefault().Cnpj.Should().BeEquivalentTo(model.Cnpj);
        actual.FirstOrDefault().Email.Should().BeEquivalentTo(model.Email);
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));
    }
}
