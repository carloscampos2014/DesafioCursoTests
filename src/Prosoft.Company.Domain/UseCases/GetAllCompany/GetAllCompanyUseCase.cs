using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.GetAllCompany;

public class GetAllCompanyUseCase : IGetAllCompanyUseCase
{
    private readonly ICompanyRepository _empresasRepository;

    public GetAllCompanyUseCase(ICompanyRepository empresasRepository)
    {
        _empresasRepository = empresasRepository;
    }

    public ResultModel Execute()
    {
        try
        {
            return new ResultModel()
            {
                Sucesso = true,
                Empresas = _empresasRepository.GetAll(),
            };
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
