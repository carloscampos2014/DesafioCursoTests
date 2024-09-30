using System.Reflection;
using Prosoft.Company.Domain.Contracts;
using Prosoft.Company.Domain.Entities;

namespace Prosoft.Company.Domain.UseCases.DeleteCompany;

public class DeleteCompanyUseCase : IDeleteCompanyUseCase
{
    private readonly ICompanyRepository _empresasRepository;

    public DeleteCompanyUseCase(ICompanyRepository empresasRepository)
    {
        _empresasRepository = empresasRepository;
    }

    public ResultModel Execute(Guid id)
    {
        try
        {
            var companyCadastrada = _empresasRepository.GetById(id);
            if (companyCadastrada == null)
            {
                throw new InvalidOperationException("Empresa não Cadastrada.");
            }

            return new ResultModel()
            {
                Sucesso = _empresasRepository.Delete(id),
                Empresa = companyCadastrada,
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
