using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.GetByCnpjCompany;

public class GetByCnpjCompanyUseCase : IGetByCnpjCompanyUseCase
{
    private readonly ICompanyRepository _empresasRepository;

    public GetByCnpjCompanyUseCase(ICompanyRepository empresasRepository)
    {
        _empresasRepository = empresasRepository;
    }

    public ResultModel Execute(string cnpj)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(cnpj))
            {
                throw new InvalidOperationException("Você deve informar o CNPJ para consulta.");
            }

            var result = new ResultModel();
            var model = _empresasRepository.GetByCnpj(cnpj);
            result.Sucesso = model != null;
            result.Empresa = model ?? new CompanyModel();
            return result;
        }
        catch (Exception ex)
        {
            return new ResultModel()
            {
                MensagemErro = ex.Message,
            };
        }
    }
}
