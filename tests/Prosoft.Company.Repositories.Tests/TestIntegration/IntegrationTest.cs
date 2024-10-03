using Bogus;
using Bogus.Extensions.Brazil;
using FluentAssertions;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Domain.Services;
using Prosoft.Company.Domain.UseCases.AddCompany;
using Prosoft.Company.Domain.UseCases.DeleteCompany;
using Prosoft.Company.Domain.UseCases.GetAllCompany;
using Prosoft.Company.Domain.UseCases.GetByCnpjCompany;
using Prosoft.Company.Domain.UseCases.UpdateCompany;
using Prosoft.Company.Domain.Validators;
using Prosoft.Company.Repositories.Tests.Fixtures;
using Sprache;
using Xunit;
using Xunit.Abstractions;

namespace Prosoft.Company.Repositories.Tests.TestIntegration;

[Collection("Database")]
public class IntegrationTest
{
    private readonly ITestOutputHelper _output;
    private readonly DatabaseFixture _fixture;
    private readonly IAddCompanyUseCase _addCompanyUseCase;
    private readonly IDeleteCompanyUseCase _deleteCompanyUseCase;
    private readonly IGetAllCompanyUseCase _getAllCompanyUseCase;
    private readonly IGetByCnpjCompanyUseCase _getByCnpjCompanyUseCase;
    private readonly IUpdateCompanyUseCase _updateCompanyUseCase;

    public IntegrationTest(DatabaseFixture fixture, ITestOutputHelper output)
    {
        _fixture = fixture;
        var serviceProvider = new ServiceCollection()
            .AddScoped<IConfigManager, AppConfigManager>()
            .AddScoped<IDbConnectionFactory, DbConnectionFactory>()
            .AddScoped<ICompanyRepository, CompanyRepository>()
            .AddScoped<IValidator<CompanyModel>, CompanyValidator>()
            .AddScoped<IAddCompanyUseCase, AddCompanyUseCase>()
            .AddScoped<IDeleteCompanyUseCase, DeleteCompanyUseCase>()
            .AddScoped<IGetAllCompanyUseCase, GetAllCompanyUseCase>()
            .AddScoped<IGetByCnpjCompanyUseCase, GetByCnpjCompanyUseCase>()
            .AddScoped<IUpdateCompanyUseCase, UpdateCompanyUseCase>()
            .BuildServiceProvider();
        _addCompanyUseCase = serviceProvider.GetRequiredService<IAddCompanyUseCase>();
        _deleteCompanyUseCase = serviceProvider.GetRequiredService<IDeleteCompanyUseCase>();
        _getAllCompanyUseCase = serviceProvider.GetRequiredService<IGetAllCompanyUseCase>();
        _getByCnpjCompanyUseCase = serviceProvider.GetRequiredService<IGetByCnpjCompanyUseCase>();
        _updateCompanyUseCase = serviceProvider.GetRequiredService<IUpdateCompanyUseCase>();
        _output = output;
    }

    [Theory(DisplayName = "Deve Adicionar Empresa Quando Receber Dados Validos")]
    [MemberData(nameof(CreateValues))]
    public void Should_AddCompany_WhenRecibeValidData(CompanyModel model)
    {
        // Arrange
        DateTime inicial = DateTime.Now;

        // Act
        var actual = _addCompanyUseCase.Execute(model);
        DateTime final = DateTime.Now;
        TimeSpan ts = final.Subtract(inicial);
        _output.WriteLine($"Tempo Processamento: {ts.TotalSeconds:N2} sec");
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));
        var dataSaved = _getByCnpjCompanyUseCase.Execute(model.Cnpj);

        // Asserts
        actual.Sucesso.Should().BeTrue();
        dataSaved.Empresa.Nome.Should().Be(model.Nome);
        dataSaved.Empresa.Endereco.Should().Be(model.Endereco);
        dataSaved.Empresa.Telefone.Should().Be(model.Telefone);
        dataSaved.Empresa.Email.Should().Be(model.Email);
    }

    [Theory(DisplayName = "Deve Delete Empresa Quando Receber Dados Validos")]
    [MemberData(nameof(CreateValues))]
    public void Should_DeleteCompany_WhenRecibeValidData(CompanyModel model)
    {
        // Arrange
        _fixture.RemoveModel();
        DateTime inicial = DateTime.Now;
        _fixture.AddModel(model);

        // Act
        var actual = _deleteCompanyUseCase.Execute(model.Id);
        DateTime final = DateTime.Now;
        TimeSpan ts = final.Subtract(inicial);
        _output.WriteLine($"Tempo Processamento: {ts.TotalSeconds:N2} sec");
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));
        var dataSaved = _getByCnpjCompanyUseCase.Execute(model.Cnpj);

        // Asserts
        actual.Sucesso.Should().BeTrue();
        dataSaved.Sucesso.Should().BeFalse();
        dataSaved.Empresa.Nome.Should().BeEmpty();
        dataSaved.Empresa.Cnpj.Should().BeEmpty();
        dataSaved.Empresa.Endereco.Should().BeEmpty();
        dataSaved.Empresa.Telefone.Should().BeEmpty();
        dataSaved.Empresa.Email.Should().BeEmpty();
    }

    [Theory(DisplayName = "Deve Recuperar Empresas Quando Receber Dados Validos")]
    [MemberData(nameof(CreateValues))]
    public void Should_GetAllCompany_WhenRecibeValidData(CompanyModel model)
    {
        // Arrange
        _fixture.RemoveModel();
        DateTime inicial = DateTime.Now;
        _fixture.AddModel(model);

        // Act
        var actual = _getAllCompanyUseCase.Execute();
        DateTime final = DateTime.Now;
        TimeSpan ts = final.Subtract(inicial);
        _output.WriteLine($"Tempo Processamento: {ts.TotalSeconds:N2} sec");
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));

        // Asserts
        actual.Sucesso.Should().BeTrue();
        actual.Empresas.Any().Should().BeTrue();
        actual.Empresas.FirstOrDefault()?.Nome.Should().Be(model.Nome);
        actual.Empresas.FirstOrDefault()?.Endereco.Should().Be(model.Endereco);
        actual.Empresas.FirstOrDefault()?.Telefone.Should().Be(model.Telefone);
        actual.Empresas.FirstOrDefault()?.Email.Should().Be(model.Email);
    }

    [Theory(DisplayName = "Deve Recuperar Empresa Por CNPJ Quando Receber Dados Validos")]
    [MemberData(nameof(CreateValues))]
    public void Should_GetByCnpjCompany_WhenRecibeValidData(CompanyModel model)
    {
        // Arrange
        _fixture.RemoveModel();
        DateTime inicial = DateTime.Now;
        _fixture.AddModel(model);

        // Act
        var actual = _getByCnpjCompanyUseCase.Execute(model.Cnpj);
        DateTime final = DateTime.Now;
        TimeSpan ts = final.Subtract(inicial);
        _output.WriteLine($"Tempo Processamento: {ts.TotalSeconds:N2} sec");
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));

        // Asserts
        actual.Sucesso.Should().BeTrue();
        actual.Empresa.Nome.Should().Be(model.Nome);
        actual.Empresa.Endereco.Should().Be(model.Endereco);
        actual.Empresa.Telefone.Should().Be(model.Telefone);
        actual.Empresa.Email.Should().Be(model.Email);
    }

    [Theory(DisplayName = "Deve Update Empresa Quando Receber Dados Validos")]
    [MemberData(nameof(CreateValues))]
    public void Should_UpdateCompany_WhenRecibeValidData(CompanyModel model)
    {
        // Arrange
        _fixture.RemoveModel();
        DateTime inicial = DateTime.Now;
        _fixture.AddModel(model);
        model.Nome = "Carlos Campos Ltda";
        model.Endereco = "Rua Trecento, 300";
        model.Telefone = "11978788585";
        model.Email = "carlos.seila@campos.org.br";

        // Act
        var actual = _updateCompanyUseCase.Execute(model);
        DateTime final = DateTime.Now;
        TimeSpan ts = final.Subtract(inicial);
        _output.WriteLine($"Tempo Processamento: {ts.TotalSeconds:N2} sec");
        _output.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(actual));
        var dataSaved = _getByCnpjCompanyUseCase.Execute(model.Cnpj);

        // Asserts
        actual.Sucesso.Should().BeTrue();
        dataSaved.Empresa.Nome.Should().Be(model.Nome);
        dataSaved.Empresa.Endereco.Should().Be(model.Endereco);
        dataSaved.Empresa.Telefone.Should().Be(model.Telefone);
        dataSaved.Empresa.Email.Should().Be(model.Email);
    }

    public static IEnumerable<object[]> CreateValues()
    {
        var faker = new Faker<CompanyModel>("pt_BR")
            .RuleFor(e => e.Id, f => f.Random.Guid())
            .RuleFor(e => e.Nome, f => f.Company.CompanyName())
            .RuleFor(e => e.Cnpj, f => f.Company.Cnpj(false))
            .RuleFor(e => e.Endereco, f => f.Address.FullAddress())
            .RuleFor(e => e.Telefone, f => f.Phone.PhoneNumber("###########"))
            .RuleFor(e => e.Email, f => f.Internet.Email());

        return faker.Generate(10).Select(e => new object[] { e });
    }

}
