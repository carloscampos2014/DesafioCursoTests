using FluentValidation.Results;
using FluentValidation;
using Moq;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;
using FluentAssertions;
using Prosoft.Company.Domain.UseCases.UpdateCompany;
using Xunit;

namespace Prosoft.Company.Domain.Tests.UseCases.UpdateCompany;

public class UpdateCompanyUseCaseTest
{
    [Fact(DisplayName = "Não Deve Atualizar Empresa Quando Receber Dados Inválidos")]
    public void Should_NotUpdateCompany_WhenRecibeInvalidData()
    {
        //Arrange
        CompanyModel model = null;
        Guid id = Guid.NewGuid();
        var validatorMock = new Mock<IValidator<CompanyModel>>();
        var resultValidation = new ValidationResult(new List<ValidationFailure> { new ValidationFailure(typeof(CompanyModel).Name, "O objeto empresa não pode ser nulo.") });
        validatorMock.Setup(s => s.Validate(model)).Returns(resultValidation);
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetById(id)).Returns(model);
        repositoryMock.Setup(s => s.Update(model)).Returns(false);
        IUpdateCompanyUseCase useCase = new UpdateCompanyUseCase(validatorMock.Object, repositoryMock.Object);

        //Act
        var actual = useCase.Execute(model);

        //Asserts
        actual.Sucesso.Should().BeFalse();
        actual.MensagemErro.Should().Contain("O objeto empresa não pode ser nulo.");
        validatorMock.Verify(s => s.Validate(model), Times.Exactly(1));
        repositoryMock.Verify(s => s.GetById(id), Times.Never);
        repositoryMock.Verify(s => s.Update(model), Times.Never);
    }

    [Fact(DisplayName = "Não Deve Atualizar Empresa Quando Não Encontrar Registro")]
    public void Should_NotUpdateCompany_WhenRegisterNotFound()
    {
        //Arrange
        CompanyModel model = ModelFaker.CreateModel();
        Guid id = model.Id;
        CompanyModel modelUpdate = null;
        var validatorMock = new Mock<IValidator<CompanyModel>>();
        var resultValidation = new ValidationResult();
        validatorMock.Setup(s => s.Validate(model)).Returns(resultValidation);
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetById(id)).Returns(modelUpdate);
        repositoryMock.Setup(s => s.Update(model)).Returns(false);
        IUpdateCompanyUseCase useCase = new UpdateCompanyUseCase(validatorMock.Object, repositoryMock.Object);

        //Act
        var actual = useCase.Execute(model);

        //Asserts
        actual.Sucesso.Should().BeFalse();
        actual.MensagemErro.Should().Contain("Empresa não Cadastrada.");
        validatorMock.Verify(s => s.Validate(model), Times.Exactly(1));
        repositoryMock.Verify(s => s.GetById(id), Times.Exactly(1));
        repositoryMock.Verify(s => s.Update(model), Times.Never);
    }

    [Fact(DisplayName = "Não Deve Atualizar Empresa Quando Tentar Modificar CNPJ")]
    public void Should_NotUpdateCompany_WhenTryModifyCnpj()
    {
        //Arrange
        CompanyModel model = ModelFaker.CreateModel();
        Guid id = model.Id;
        CompanyModel modelUpdate = ModelFaker.CreateModel();
        var validatorMock = new Mock<IValidator<CompanyModel>>();
        var resultValidation = new ValidationResult();
        validatorMock.Setup(s => s.Validate(model)).Returns(resultValidation);
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetById(id)).Returns(modelUpdate);
        repositoryMock.Setup(s => s.Update(model)).Returns(false);
        IUpdateCompanyUseCase useCase = new UpdateCompanyUseCase(validatorMock.Object, repositoryMock.Object);

        //Act
        var actual = useCase.Execute(model);

        //Asserts
        actual.Sucesso.Should().BeFalse();
        actual.MensagemErro.Should().Contain("Não é permitido alteração de CNPJ.");
        validatorMock.Verify(s => s.Validate(model), Times.Exactly(1));
        repositoryMock.Verify(s => s.GetById(id), Times.Exactly(1));
        repositoryMock.Verify(s => s.Update(model), Times.Never);
    }

    [Fact(DisplayName = "Deve Atualizar Empresa Quando Receber Dados Validos")]
    public void Should_UpdateCompany_WhenRecibeValidData()
    {
        //Arrange
        CompanyModel model = ModelFaker.CreateModel();
        Guid id = model.Id;
        CompanyModel modelUpdate = ModelFaker.CreateModel();
        modelUpdate.Cnpj = model.Cnpj;
        var validatorMock = new Mock<IValidator<CompanyModel>>();
        var resultValidation = new ValidationResult();
        validatorMock.Setup(s => s.Validate(model)).Returns(resultValidation);
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetById(id)).Returns(modelUpdate);
        repositoryMock.Setup(s => s.Update(model)).Returns(true);
        IUpdateCompanyUseCase useCase = new UpdateCompanyUseCase(validatorMock.Object, repositoryMock.Object);

        //Act
        var actual = useCase.Execute(model);

        //Asserts
        actual.Sucesso.Should().BeTrue();
        actual.MensagemErro.Should().BeEmpty();
        actual.Empresa.Should().BeEquivalentTo(model);
        validatorMock.Verify(s => s.Validate(model), Times.Exactly(1));
        repositoryMock.Verify(s => s.GetById(id), Times.Exactly(1));
        repositoryMock.Verify(s => s.Update(model), Times.Exactly(1));
    }
}
