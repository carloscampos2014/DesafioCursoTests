using FluentAssertions;
using Moq;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;
using Prosoft.Company.Domain.UseCases.GetByCnpjCompany;
using Xunit;

namespace Prosoft.Company.Domain.Tests.UseCases.GetByCnpjCompany;

public class GetByCnpjCompanyUseCaseTest
{
    [Fact(DisplayName = "Deve Recuperar Objeto Nulo Quando Receber CNPJ em Branco")]
    public void Should_GetNullObject_WhenRecibeEmptyCNPJ()
    {
        //Arrange
        CompanyModel model = null;
        string cnpj = string.Empty;
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetByCnpj(cnpj)).Returns(model);
        IGetByCnpjCompanyUseCase useCase = new GetByCnpjCompanyUseCase(repositoryMock.Object);

        //Act
        var actual = useCase.Execute(cnpj);

        //Asserts
        actual.Sucesso.Should().BeFalse();
        actual.MensagemErro.Should().Contain("Você deve informar o CNPJ para consulta.");
        repositoryMock.Verify(s => s.GetByCnpj(cnpj), Times.Never);
    }

    [Fact(DisplayName = "Deve Recuperar Objeto Company Quando Encontrar Registro")]
    public void Should_GetCompanyObject_WhenFoundRegister()
    {
        //Arrange
        CompanyModel model = ModelFaker.CreateModel();
        string cnpj = model.Cnpj;
        var repositoryMock = new Mock<ICompanyRepository>();
        repositoryMock.Setup(s => s.GetByCnpj(cnpj)).Returns(model);
        IGetByCnpjCompanyUseCase useCase = new GetByCnpjCompanyUseCase(repositoryMock.Object);

        //Act
        var actual = useCase.Execute(cnpj);

        //Asserts
        actual.Sucesso.Should().BeTrue();
        actual.MensagemErro.Should().BeEmpty();
        actual.Empresa.Should().BeEquivalentTo(model);
        repositoryMock.Verify(s => s.GetByCnpj(cnpj), Times.Exactly(1));
    }
}
