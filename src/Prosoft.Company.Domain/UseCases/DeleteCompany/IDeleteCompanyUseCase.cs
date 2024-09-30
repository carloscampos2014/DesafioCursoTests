using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.DeleteCompany;

public interface IDeleteCompanyUseCase
{
    ResultModel Execute(Guid id);
}
