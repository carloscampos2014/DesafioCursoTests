using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.GetByCnpjCompany;

public interface IGetByCnpjCompanyUseCase
{
    ResultModel Execute(string cnpj);
}
