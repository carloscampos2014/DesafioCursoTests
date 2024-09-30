using FluentAssertions;
using Moq;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.UseCases.GetAllCompany;
using Xunit;

namespace Prosoft.Company.Domain.Tests.UseCases.GetAllCmpany;

public class GetAllCompanyUseCaseTest
{
    [Fact(DisplayName = "Deve Recuperar Lista Vazia Quando Ocorrer Erro no DB")]
    public void Should_GetListEmpty_WhenOccuredErroDB()
    {
        //Arrange
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetAll()).Throws<Exception>(() => new InvalidOperationException("Erro n Banco de Dados."));
        IGetAllCompanyUseCase useCase = new GetAllCompanyUseCase(repositoryMock.Object);

        //Act
        var actual = useCase.Execute();

        //Asserts
        actual.Sucesso.Should().BeFalse();
        actual.MensagemErro.Should().Contain("Erro n Banco de Dados.");
        actual.Empresas.Any().Should().BeFalse();
        repositoryMock.Verify(s => s.GetAll(), Times.Exactly(1));
    }

    [Fact(DisplayName = "Deve Recuperar Lista Preenchida Quando Existir Registros")]
    public void Should_GetList_WhenHaveRegister()
    {
        //Arrange
        var models = ModelFaker.CreateModel(10);
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetAll()).Returns(models);
        IGetAllCompanyUseCase useCase = new GetAllCompanyUseCase(repositoryMock.Object);

        //Act
        var actual = useCase.Execute();

        //Asserts
        actual.Sucesso.Should().BeTrue();
        actual.MensagemErro.Should().BeEmpty();
        actual.Empresas.Any().Should().BeTrue();
        actual.Empresas.Should().BeEquivalentTo(models);
        repositoryMock.Verify(s => s.GetAll(), Times.Exactly(1));
    }
}
