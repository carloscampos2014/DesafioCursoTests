using Bogus;
using Bogus.Extensions.Brazil;
using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.Tests;

public static class ModelFaker
{
    public static CompanyModel CreateModel()
    {
        var faker = new Faker<CompanyModel>("pt_BR")
            .RuleFor(e => e.Id, f => f.Random.Guid())
            .RuleFor(e => e.Nome, f => f.Company.CompanyName())
            .RuleFor(e => e.Cnpj, f => f.Company.Cnpj(false))
            .RuleFor(e => e.Endereco, f => f.Address.FullAddress())
            .RuleFor(e => e.Telefone, f => f.Phone.PhoneNumber("###########"))
            .RuleFor(e => e.Email, f => f.Internet.Email());
        return faker.Generate();
    }

    public static IEnumerable<CompanyModel> CreateModel(int number)
    {
        var faker = new Faker<CompanyModel>("pt_BR")
            .RuleFor(e => e.Id, f => f.Random.Guid())
            .RuleFor(e => e.Nome, f => f.Company.CompanyName())
            .RuleFor(e => e.Cnpj, f => f.Company.Cnpj(false))
            .RuleFor(e => e.Endereco, f => f.Address.FullAddress())
            .RuleFor(e => e.Telefone, f => f.Phone.PhoneNumber("###########"))
            .RuleFor(e => e.Email, f => f.Internet.Email());
        return faker.Generate(number);
    }
}
