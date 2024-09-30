using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.UpdateCompany;

public interface IUpdateCompanyUseCase
{
    ResultModel Execute(CompanyModel model);
}
