using FluentAssertions;
using FluentValidation.Results;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Domain.Validators;
using Xunit;

namespace Prosoft.Company.Domain.Tests.Validators;
public class EmpresaValidatorTest
{
    [Fact(DisplayName = "Deve Validar Corretamente Quando Receber Dados Válidos.")]
    public void Should_ValidateCorrectly_WhenReceivingValidData()
    {
        //Arrange
        CompanyModel model = ModelFaker.CreateModel();
        var validator = new CompanyValidator();

        //Act
        var actual = validator.Validate(model);

        //Asserts
        actual.IsValid.Should().BeTrue();
        actual.Errors.Should().BeEmpty();
    }

    [Fact(DisplayName = "Deve Retornar Erro de Validação Quando Receber Objeto Nulo.")]
    public void Should_ReturnValidationError_WhenReceivingNullObject()
    {
        //Arrange
        CompanyModel model = null;
        var validator = new CompanyValidator();
        var expected = new ValidationFailure(typeof(CompanyModel).Name, "O objeto empresa não pode ser nulo.");

        //Act
        var actual = validator.Validate(model);

        //Asserts
        actual.IsValid.Should().BeFalse();
        actual.Errors.Should().NotBeEmpty();
        actual.Errors.First().Should().BeEquivalentTo(expected);
    }

    [Theory(DisplayName = "Deve Retornar Erro de Validação Quando Receber Dados Inválidos")]
    [MemberData(nameof(CreateErroValidations))]
    public void Should_ReturnValidationError_WhenReceivingInvalidData(
        string nome,
        string cnpj,
        string endereco,
        string telefone,
        string email,
        IEnumerable<ValidationFailure> expecteds)
    {
        //Arrange
        var model = new CompanyModel
        {
            Nome = nome,
            Cnpj = cnpj,
            Endereco = endereco,
            Telefone = telefone,
            Email = email,
        };
        var validator = new CompanyValidator();

        //Act
        var actual = validator.Validate(model);

        //Asserts
        actual.IsValid.Should().BeFalse();
        actual.Errors.Should().NotBeEmpty();
        foreach (var expectedError in expecteds)
        {
            var matchingError = actual.Errors.SingleOrDefault(e => e.PropertyName == expectedError.PropertyName && e.ErrorMessage == expectedError.ErrorMessage);
            matchingError.Should().NotBeNull();
        }
    }

    public static IEnumerable<object[]> CreateErroValidations()
    {
        var nomeEmpty = new ValidationFailure("Nome", "Nome é obrigatário.");
        var nomeLength = new ValidationFailure("Nome", "O Nome deve ter entre 3 e 200 Letras.");
        var cnpjEmpty = new ValidationFailure("Cnpj", "CNPJ é obrigatário.");
        var cnpjInvalid = new ValidationFailure("Cnpj", "CNPJ Inválido.");
        var enderecoEmpty = new ValidationFailure("Endereco", "Endereço é obrigatário.");
        var enderecoLength = new ValidationFailure("Endereco", "O Endereço deve ter entre 3 e 200 Letras.");
        var telefoneEmpty = new ValidationFailure("Telefone", "Telefone é obrigatório.");
        var telefoneInvalid = new ValidationFailure("Telefone", "Telefone Inválido.");
        var emailEmpty = new ValidationFailure("Email", "E-Mail é obrigatário.");
        var emailInvalid = new ValidationFailure("Email", "E-Mail Inválido.");

        yield return new object[] { null, null, null, null, null,
            new[] {
                nomeEmpty,
                cnpjEmpty,
                cnpjInvalid,
                enderecoEmpty,
                telefoneEmpty,
                emailEmpty,
        }};

        yield return new object[] { "", "", "", "", "",
            new[] {
                nomeEmpty,
                nomeLength,
                cnpjEmpty,
                cnpjInvalid,
                enderecoEmpty,
                enderecoLength,
                telefoneEmpty,
                telefoneInvalid,
                emailEmpty,
                emailInvalid,
        }};

        yield return new object[] { "", "", "", "", "",
            new[] {
                nomeEmpty,
                nomeLength,
                cnpjEmpty,
                cnpjInvalid,
                enderecoEmpty,
                enderecoLength,
                telefoneEmpty,
                telefoneInvalid,
                emailEmpty,
                emailInvalid,
        }};
    }
}
