using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Domain.UseCases.AddCompany;
using Xunit;

namespace Prosoft.Company.Domain.Tests.UseCases.AddCompany;

public class AddCompanyUseCaseTest
{
    [Fact(DisplayName = "Não Deve Adicionar Empresa Quando Receber Dados Inválidos")]
    public void Should_NotAddCompany_WhenRecibeInvalidData()
    {
        //Arrange
        CompanyModel model = null;
        string cnpj = string.Empty;
        var validatorMock = new Mock<IValidator<CompanyModel>>();
        var resultValidation = new ValidationResult(new List<ValidationFailure> { new ValidationFailure(typeof(CompanyModel).Name, "O objeto empresa não pode ser nulo.") });
        validatorMock.Setup(s => s.Validate(model)).Returns(resultValidation);
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetByCnpj(cnpj)).Returns(model);
        repositoryMock.Setup(s => s.Add(model)).Returns(false);
        IAddCompanyUseCase useCase = new AddCompanyUseCase(validatorMock.Object, repositoryMock.Object);

        //Act
        var actual = useCase.Execute(model);

        //Asserts
        actual.Sucesso.Should().BeFalse();
        actual.MensagemErro.Should().Contain("O objeto empresa não pode ser nulo.");
        validatorMock.Verify(s => s.Validate(model), Times.Exactly(1));
        repositoryMock.Verify(s => s.GetByCnpj(cnpj), Times.Never);
        repositoryMock.Verify(s => s.Add(model), Times.Never);
    }

    [Fact(DisplayName = "Não Deve Adicionar Empresa Quando O CNPJ já esta Cadastrado")]
    public void Should_NotAddCompany_WhenCnpjHasRegistred()
    {
        //Arrange
        CompanyModel model = ModelFaker.CreateModel();
        string cnpj = model.Cnpj;
        var validatorMock = new Mock<IValidator<CompanyModel>>();
        var resultValidation = new ValidationResult();
        validatorMock.Setup(s => s.Validate(model)).Returns(resultValidation);
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetByCnpj(cnpj)).Returns(model);
        repositoryMock.Setup(s => s.Add(model)).Returns(false);
        IAddCompanyUseCase useCase = new AddCompanyUseCase(validatorMock.Object, repositoryMock.Object);

        //Act
        var actual = useCase.Execute(model);

        //Asserts
        actual.Sucesso.Should().BeFalse();
        actual.MensagemErro.Should().Contain("Já existe um empresa cadastrada com esse CNPJ");
        validatorMock.Verify(s => s.Validate(model), Times.Exactly(1));
        repositoryMock.Verify(s => s.GetByCnpj(cnpj), Times.Exactly(1));
        repositoryMock.Verify(s => s.Add(model), Times.Never);
    }

    [Fact(DisplayName = "Deve Adicionar Empresa Quando Receber Dados Válidos")]
    public void Should_AddCompany_WhenRecibeValidData()
    {
        //Arrange
        CompanyModel model = ModelFaker.CreateModel();
        string cnpj = model.Cnpj;
        CompanyModel modelCadastro = null;
        var validatorMock = new Mock<IValidator<CompanyModel>>();
        var resultValidation = new ValidationResult();
        validatorMock.Setup(s => s.Validate(model)).Returns(resultValidation);
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetByCnpj(cnpj)).Returns(modelCadastro);
        repositoryMock.Setup(s => s.Add(model)).Returns(true);
        IAddCompanyUseCase useCase = new AddCompanyUseCase(validatorMock.Object, repositoryMock.Object);

        //Act
        var actual = useCase.Execute(model);

        //Asserts
        actual.Sucesso.Should().BeTrue();
        actual.MensagemErro.Should().BeEmpty();
        actual.Empresa.Should().BeEquivalentTo(model);
        validatorMock.Verify(s => s.Validate(model), Times.Exactly(1));
        repositoryMock.Verify(s => s.GetByCnpj(cnpj), Times.Exactly(1));
        repositoryMock.Verify(s => s.Add(model), Times.Exactly(1));
    }

}
