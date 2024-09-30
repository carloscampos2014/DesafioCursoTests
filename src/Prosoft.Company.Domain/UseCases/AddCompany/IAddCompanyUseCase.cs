using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.AddCompany;

public interface IAddCompanyUseCase
{
    ResultModel Execute(CompanyModel model);
}
