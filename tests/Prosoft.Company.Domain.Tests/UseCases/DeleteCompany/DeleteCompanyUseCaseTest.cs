using FluentAssertions;
using Moq;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Domain.UseCases.DeleteCompany;
using Xunit;

namespace Prosoft.Company.Domain.Tests.UseCases.DeleteCompany;

public class DeleteCompanyUseCaseTest
{
    [Fact(DisplayName = "Não Deve Excluir Empresa Quando Não Encontrar Registro")]
    public void Should_NotDeleteCompany_WhenRegisterNotFound()
    {
        //Arrange
        CompanyModel model = null;
        Guid id = Guid.NewGuid();
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetById(id)).Returns(model);
        repositoryMock.Setup(s => s.Delete(id)).Returns(false);
        IDeleteCompanyUseCase useCase = new DeleteCompanyUseCase(repositoryMock.Object);

        //Act
        var actual = useCase.Execute(id);

        //Asserts
        actual.Sucesso.Should().BeFalse();
        actual.MensagemErro.Should().Contain("Empresa não Cadastrada.");
        repositoryMock.Verify(s => s.GetById(id), Times.Exactly(1));
        repositoryMock.Verify(s => s.Delete(id), Times.Never);
    }

    [Fact(DisplayName = "Deve Excluir Empresa Quando Encontrar Registro")]
    public void Should_DeleteCompany_WhenFoundRegister()
    {
        //Arrange
        CompanyModel model = ModelFaker.CreateModel();
        Guid id = model.Id;
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetById(id)).Returns(model);
        repositoryMock.Setup(s => s.Delete(id)).Returns(true);
        IDeleteCompanyUseCase useCase = new DeleteCompanyUseCase(repositoryMock.Object);

        //Act
        var actual = useCase.Execute(id);

        //Asserts
        actual.Sucesso.Should().BeTrue();
        actual.MensagemErro.Should().BeEmpty();
        actual.Empresa.Should().BeEquivalentTo(model);
        repositoryMock.Verify(s => s.GetById(id), Times.Exactly(1));
        repositoryMock.Verify(s => s.Delete(id), Times.Exactly(1));
    }
}
