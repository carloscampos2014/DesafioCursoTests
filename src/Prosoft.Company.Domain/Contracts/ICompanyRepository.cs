using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.Contracts;

public interface ICompanyRepository
{
    CompanyModel? GetByCnpj(string cnpj);

    CompanyModel? GetById(Guid id);

    IEnumerable<CompanyModel> GetAll();

    bool Add(CompanyModel model);

    bool Update(CompanyModel model);

    bool Delete(Guid id);
}
